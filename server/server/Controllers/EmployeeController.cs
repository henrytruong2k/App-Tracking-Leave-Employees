using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Entities;
using server.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeHandler _employeeHandler;

        public EmployeeController(IEmployeeHandler employeeHandler)
        {
            _employeeHandler = employeeHandler;
        }


        // GET: api/<EmployeeController>
        [Authorize(Roles = Role.HR)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _employeeHandler.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   ex);
            }
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var result = await _employeeHandler.GetApprover(id);
                if(result == null) return NotFound();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  ex);
            }
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApprover(int id)
        {
            try
            {
                var result = await _employeeHandler.Get(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  ex);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto userLogin)
        {
            try
            {
                var user = await _employeeHandler.Authenticate(userLogin.Email, userLogin.Password);
                if (user == null) return BadRequest(new { message = "Email or password is incorrect" });
                return Ok(user);
            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex);
            }
        }

        [Authorize(Roles = Role.HR)]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto emp)
        {
            try
            {
                return Ok(await _employeeHandler.Add(emp));
            }
            catch(Exception)
            {
                return BadRequest();
            }
            
        }

        [Authorize(Roles = Role.HR)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmploye(int id, [FromBody] EmployeeDto emp)
        {
            try
            {
                if (id != emp.Id) return BadRequest();
                var result = await _employeeHandler.Update(emp);
                if (result == null) return NotFound();
                return Ok(result);
            } 
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex);
            }
        }

    }
}
