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
    public class TableController : ControllerBase
    {
        /// <summary>
        /// Return a list of items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> Get()
        {
            try
            {
                return Ok(await TableManager.Load());
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
        public async Task<ActionResult<Table>> Get(Guid id)
        {
            try
            {
                return Ok(await TableManager.LoadById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        

        /// <summary>
        /// Insert a new item
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="rollback"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Table Table, bool rollback = false)
        {
            try
            {
                return Ok(await TableManager.Insert(Table, rollback));
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
        /// <param name="Table"></param>
        /// <param name="rollback"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Table Table, bool rollback = false)
        {
            try
            {
                return Ok(await TableManager.Update(Table, rollback));
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
                return Ok(await TableManager.Delete(id, rollback));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}