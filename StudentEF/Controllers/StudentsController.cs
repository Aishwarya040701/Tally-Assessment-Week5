using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEF;
using StudentEF.Interface;
using StudentEF.Models;

namespace StudentEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudent _repo;

        public StudentsController(IStudent repo)
        {
            _repo = repo;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                var result =  _repo.GetStudents().ToList();
                return Ok(result);
            }
            catch (Exception ex)

            {
                return BadRequest(ex);
            }
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudent(int id)
        {
            try
            {
                if (_repo.checkId(id))
                {
                    var result =  _repo.GetStudentById(id);
                    
                    return Ok(result);
                }

                return NotFound("Id does not exists");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostStudent(Student student)
        {
            try
            {
                var result = _repo.PostStudent(student);
                
                    return Ok(result);
                
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            //if (id != student.StudentId)
            //{
            //    return BadRequest();
            //}
            try
            {
                if (_repo.checkId(id))
                {
                    var result = _repo.PutStudent(student);



                    return Ok(result);
                }

                return NotFound("Id does not exists");
            }
            catch (Exception ex)
            {
             return BadRequest(ex);
            }
        }



        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {

            try
            {
                if (_repo.checkId(id))
                {
                    var result = _repo.DeleteStudent(id);


                    return Ok(result);
                }

                return NotFound("Id does not exists");

            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }

      
    }
}
