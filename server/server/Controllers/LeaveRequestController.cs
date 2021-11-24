using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Entities;
using server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestHandler _leaveRequestHandler;

        public LeaveRequestController(ILeaveRequestHandler leaveRequestHandler)
        {
            _leaveRequestHandler = leaveRequestHandler;
        }
        // GET: api/<LeaveRequestController>
        [Authorize(Roles = Role.HR)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] LeaveRequestFiltersDto filter)
        {
            try
            {
                return Ok(await _leaveRequestHandler.GetAll(filter));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   ex);
            }
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> MyLeave(int id)
        {
            try
            {
                return Ok(await _leaveRequestHandler.GetLeaveRequestsByEmployee(id));
            } 
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   ex);
            }
        }
        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var result = await _leaveRequestHandler.FindById(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   ex);
            }
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public async Task<IActionResult> AddLeaveRequest([FromBody] LeaveRequestDto model)
        {
            try
            {
                var result = await _leaveRequestHandler.AddLeaveRequest(model);
                if(!result.IsSuccess)
                {
                    return BadRequest(new {
                        Message = result.MessageResponse,
                    });
                }
                return Ok(result);
            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   ex);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CheckLeaveRequest(int id)
        {
            try
            {
                var result = await _leaveRequestHandler.Check(id);
                return Ok(result);
            } 
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   ex);
            }
        }

        //public async Task<IActionResult> ApproveRequest(int requestId)
        //{
        //    try
        //    {
        //        //var leaveRequest = _leaveRequestHandler.FindById(handle.LeaveRequestId);
                

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //           ex);
        //    }
        //}

        // PUT api/<LeaveRequestController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaveRequest(int id, [FromBody] LeaveRequestDto model)
        {
            try
            {
                if (id != model.Id) return BadRequest();
                var result = await _leaveRequestHandler.UpdateLeaveRequest(model);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex);
            }
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
