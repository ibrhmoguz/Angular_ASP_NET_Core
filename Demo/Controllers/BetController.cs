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
        public BetController(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }

        [HttpGet("playerList")]
        public IEnumerable<PlayerInfo> GetPlayerList()
        {
            return this._betRepository.GetPlayerListWithStatistics();
        }

        [HttpPost("createBet")]
        public int CreateBet([FromBody] Bet bet)
        {
            return this._betRepository.AddUpdateBet(bet);
        }

        [HttpPost("createEvent")]
        public int CreateEvent([FromBody] Event e)
        {
            return this._betRepository.AddUpdateEvent(e);
        }
    }
}