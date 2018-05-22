using System.Collections.Generic;
using System.Linq;
using Demo.Models;

namespace Demo.Repository
{
    public class BetRepository : IBetRepository
    {
        private readonly BetContext _betContext;
        public BetRepository(BetContext betContext)
        {
            _betContext = betContext;
        }

        public IEnumerable<PlayerInfo> GetPlayerListWithStatistics()
        {
            var playerList = from p in _betContext.Players
                             select new PlayerInfo
                             {
                                 Player = p,
                                 TotalBets = _betContext.Bets.Count(b => b.PlayerId == p.PlayerId),
                                 TotalBetsWon = (from b in _betContext.Bets.Where(b => b.PlayerId == p.PlayerId)
                                                 join e in _betContext.Events on b.EventId equals e.EventId
                                                 where b.Type == e.Result
                                                 select b.BetId).Count(),
                                 TotalBetsLost = (from b in _betContext.Bets.Where(b => b.PlayerId == p.PlayerId)
                                                  join e in _betContext.Events on b.EventId equals e.EventId
                                                  where b.Type != e.Result
                                                  select b.BetId).Count(),
                                 AmountLost = (from b in _betContext.Bets.Where(b => b.PlayerId == p.PlayerId)
                                               join e in _betContext.Events on b.EventId equals e.EventId
                                               where b.Type != e.Result
                                               select b.Amount).Sum(),
                                 AmountWon = (from b in _betContext.Bets.Where(b => b.PlayerId == p.PlayerId)
                                              join e in _betContext.Events on b.EventId equals e.EventId
                                              where b.Type == e.Result
                                              select b.Amount * (e.Result == 1 ? e.HomeOdds : e.Result == 2 ? e.AwayOdds : e.DrawOdds)).Sum()
                             };
            return playerList.ToList();
        }
    }
}
