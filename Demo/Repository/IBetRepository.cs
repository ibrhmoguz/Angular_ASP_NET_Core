﻿using System.Collections.Generic;
using Demo.Models;

namespace Demo.Repository
{
    public interface IBetRepository
    {
        IEnumerable<PlayerInfo> GetPlayerListWithStatistics();
        int AddUpdateBet(Bet bet);
        int AddUpdateEvent(Event e);
    }
}
