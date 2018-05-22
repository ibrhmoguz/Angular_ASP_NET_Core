using System.Collections.Generic;
using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Produces("application/json")]
    [Route("api/bet")]
    public class BetController : Controller
    {
        private readonly IBetRepository _betRepository;
        protected BetController(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }

        [HttpGet("playerList")]
        public IEnumerable<PlayerInfo> GetPlayerList()
        {
            return this._betRepository.GetPlayerListWithStatistics();
        }
    }
}