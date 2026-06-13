using ErtisAuth.Core.Models.Roles;
using ErtisAuth.Extensions.Authorization.Annotations;
using ErtisAuth.Identity.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace ForMIS.FormManagementApi.Controllers
{
    [Authorized]
    [RbacResource("form")]
    [Route("api/[controller]")]
    [ApiController]
    public class FormAttachmentsController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FormAttachmentsController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        [RbacAction(Rbac.CrudActions.Create)]
        [RequestSizeLimit(10_485_760)]
        public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] int formId, [FromForm] string studentNumber)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("Dosya boş");

                await using (var probe = file.OpenReadStream())
                {
                    if (!await IsAllowedMagicAsync(probe))
                        return BadRequest("İzin verilmeyen dosya tipi");
                }

                var dir = FormDir(studentNumber, formId);
                Directory.CreateDirectory(dir);

                var safeName = Path.GetFileName(file.FileName);
                if (string.IsNullOrWhiteSpace(safeName))
                    return BadRequest("Geçersiz dosya adı");

                var nameWithoutExt = Path.GetFileNameWithoutExtension(safeName);
                var ext = Path.GetExtension(safeName);
                var candidate = safeName;
                var fullPath = Path.Combine(dir, candidate);

                if (!IsInsideFormDir(dir, fullPath))
                    return BadRequest("Geçersiz dosya adı");

                var counter = 2;
                FileStream? output = null;
                while (output == null)
                {
                    try
                    {
                        output = new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write);
                    }
                    catch (IOException) when (System.IO.File.Exists(fullPath))
                    {
                        candidate = $"{nameWithoutExt}_{counter++}{ext}";
                        fullPath = Path.Combine(dir, candidate);
                    }
                }

                await using (output)
                {
                    await file.CopyToAsync(output);
                }

                var info = new FileInfo(fullPath);
                return Ok(new
                {
                    studentNumber,
                    formId,
                    fileName = candidate,
                    contentType = MimeFromExt(ext),
                    fileSize = info.Length,
                    uploadedAt = info.LastWriteTimeUtc,
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [RbacAction(Rbac.CrudActions.Read)]
        public IActionResult List([FromQuery] string studentNumber, [FromQuery] int formId)
        {
            try
            {
                var dir = FormDir(studentNumber, formId);
                if (!Directory.Exists(dir))
                    return Ok(Array.Empty<object>());

                var items = new DirectoryInfo(dir)
                    .GetFiles()
                    .OrderByDescending(f => f.LastWriteTimeUtc)
                    .Select(f => new
                    {
                        studentNumber,
                        formId,
                        fileName = f.Name,
                        contentType = MimeFromExt(f.Extension),
                        fileSize = f.Length,
                        uploadedAt = f.LastWriteTimeUtc,
                    })
                    .ToList();
                return Ok(items);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("download")]
        [RbacAction(Rbac.CrudActions.Read)]
        public IActionResult Download([FromQuery] string studentNumber, [FromQuery] int formId, [FromQuery] string fileName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileName))
                    return BadRequest("Geçersiz dosya adı");

                var safeName = Path.GetFileName(fileName);
                var dir = FormDir(studentNumber, formId);
                var path = Path.Combine(dir, safeName);

                if (!IsInsideFormDir(dir, path))
                    return BadRequest("Geçersiz dosya adı");

                if (!System.IO.File.Exists(path))
                    return NotFound();

                return File(System.IO.File.OpenRead(path), MimeFromExt(Path.GetExtension(safeName)), safeName);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [RbacAction(Rbac.CrudActions.Delete)]
        public IActionResult Delete([FromQuery] string studentNumber, [FromQuery] int formId, [FromQuery] string fileName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileName))
                    return BadRequest("Geçersiz dosya adı");

                var safeName = Path.GetFileName(fileName);
                var dir = FormDir(studentNumber, formId);
                var path = Path.Combine(dir, safeName);

                if (!IsInsideFormDir(dir, path))
                    return BadRequest("Geçersiz dosya adı");

                if (!System.IO.File.Exists(path))
                    return NotFound();

                System.IO.File.Delete(path);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private string FormDir(string studentNumber, int formId) =>
            Path.Combine(_env.ContentRootPath, "uploads", "students",
                SafeSegment(studentNumber), "forms", formId.ToString());

        private static string SafeSegment(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s.Contains("..") || s.Contains('/') || s.Contains('\\'))
                throw new ArgumentException("Geçersiz path segmenti");
            return s;
        }

        private static bool IsInsideFormDir(string formDir, string fullPath)
        {
            var resolvedDir = Path.GetFullPath(formDir);
            var resolvedFile = Path.GetFullPath(fullPath);
            return resolvedFile.StartsWith(resolvedDir + Path.DirectorySeparatorChar);
        }

        private static string MimeFromExt(string ext) => ext.ToLowerInvariant() switch
        {
            ".pdf" => "application/pdf",
            ".png" => "image/png",
            ".jpg" => "image/jpeg",
            ".jpeg" => "image/jpeg",
            _ => "application/octet-stream",
        };

        private static async Task<bool> IsAllowedMagicAsync(Stream stream)
        {
            var buf = new byte[8];
            var read = await stream.ReadAsync(buf.AsMemory(0, buf.Length));
            bool isPdf = read >= 4 && buf[0] == 0x25 && buf[1] == 0x50 && buf[2] == 0x44 && buf[3] == 0x46;
            bool isPng = read >= 8 && buf[0] == 0x89 && buf[1] == 0x50 && buf[2] == 0x4E && buf[3] == 0x47
                         && buf[4] == 0x0D && buf[5] == 0x0A && buf[6] == 0x1A && buf[7] == 0x0A;
            bool isJpeg = read >= 3 && buf[0] == 0xFF && buf[1] == 0xD8 && buf[2] == 0xFF;
            return isPdf || isPng || isJpeg;
        }
    }
}
