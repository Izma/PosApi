using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PosApi.Controllers
{
    [ApiController]
    public class GroupingController : ControllerBase
    {
        private readonly IGroupingRepository repository;
        public GroupingController(IGroupingRepository grouping)
        {
            repository = grouping;
        }

        /// <summary>
        /// Get group
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("api/grouping"), ProducesResponseType(200, Type = typeof(IList<GroupingModel>)), ProducesResponseType(404),]
        public async Task<IActionResult> Get()
        {
            var result = await repository.GetGrouping().ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Get group by id
        /// </summary>
        /// <param name="groupId">groupId</param>
        /// <returns></returns>
        [HttpGet, Route("api/grouping/{groupId}")]
        public IActionResult Get(int groupId)
        {
            throw new NotImplementedException();
        }


    }
}