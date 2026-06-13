using ErtisAuth.Core.Models.Roles;
using ErtisAuth.Extensions.Authorization.Annotations;
using ErtisAuth.Identity.Attributes;
using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForMIS.UserManagementApi.Controllers
{
    [Authorized]
    [RbacResource("departmentmember")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentMemberController : ControllerBase
    {
        private readonly IDatabaseService<DepartmentMemberDto, DepartmentMember> _service;

        public DepartmentMemberController(IDatabaseService<DepartmentMemberDto, DepartmentMember> service)
        {
            _service = service;
        }

        [HttpGet]
        [RbacAction(Rbac.CrudActions.Read)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [RbacAction(Rbac.CrudActions.Read)]
        [RbacObject("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Id is invalid!");

                var entity = await _service.GetByIdAsync((int)id);
                
                if(entity != null)
                    return Ok(entity);
                
                return NotFound("Not found!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [RbacAction(Rbac.CrudActions.Create)]
        public async Task<IActionResult> Post([FromBody] DepartmentMemberDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                await _service.AddAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [RbacAction(Rbac.CrudActions.Update)]
        public async Task<IActionResult> Put([FromBody] DepartmentMemberDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _service.UpdateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [RbacAction(Rbac.CrudActions.Delete)]
        [RbacObject("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Id is invalid!");
                
                var entity = await _service.GetByIdAsync((int)id);

                if (entity != null)
                {
                    await _service.DeleteAsync((int)id);
                    return Ok();
                }
                
                return NotFound("Not found!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
