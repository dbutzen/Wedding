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
    public class GuestController : ControllerBase
    {
        /// <summary>
        /// Return a list of items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> Get()
        {
            try
            {
                return Ok(await GuestManager.Load());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<IEnumerable<Guest>>> Get(Guid id)
        {
            try
            {
                return Ok(await GuestManager.LoadById(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        


        /// <summary>
        /// Get an item by family code
        /// </summary>
        /// <param name="familyCode"></param>
        /// <returns></returns>
        /// 

        [HttpGet("{familyCode}")]
        public async Task<ActionResult<Guest>> Get(string familyCode)
        {
            try
            {
                return Ok(await GuestManager.LoadByFamilyCode(familyCode));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        

        /// <summary>
        /// Insert a new item
        /// </summary>
        /// <param name="Guest"></param>
        /// <param name="rollback"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Guest Guest, bool rollback = false)
        {
            try
            {
                return Ok(await GuestManager.Insert(Guest, rollback));
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
        /// <param name="Guest"></param>
        /// <param name="rollback"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Guest Guest, bool rollback = false)
        {
            try
            {
                return Ok(await GuestManager.Update(Guest, rollback));
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
                return Ok(await GuestManager.Delete(id, rollback));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}