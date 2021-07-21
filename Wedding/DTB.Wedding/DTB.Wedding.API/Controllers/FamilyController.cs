using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DTB.Wedding.BL;
using DTB.Wedding.BL.Models;

namespace DTB.Wedding.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        /// <summary>
        /// Return a list of items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Family>>> Get()
        {
            try
            {
                return Ok(await FamilyManager.Load());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Get an item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Family>> Get(Guid id)
        {
            try
            {
                return Ok(await FamilyManager.LoadById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        

        /// <summary>
        /// Insert a new item
        /// </summary>
        /// <param name="Family"></param>
        /// <param name="rollback"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Family Family, bool rollback = false)
        {
            try
            {
                return Ok(await FamilyManager.Insert(Family, rollback));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Family"></param>
        /// <param name="rollback"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Family Family, bool rollback = false)
        {
            try
            {
                return Ok(await FamilyManager.Update(Family, rollback));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rollback"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, bool rollback = false)
        {
            try
            {
                return Ok(await FamilyManager.Delete(id, rollback));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}