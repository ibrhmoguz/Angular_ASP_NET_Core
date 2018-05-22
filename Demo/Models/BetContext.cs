using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Demo.Models
{
    public class BetContext : DbContext
    {
        public BetContext(DbContextOptions<BetContext> options)
            : base(options)
        { }

        public DbSet<PlayerInfo> PlayerInfos { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Event> Events { get; set; }
    }

    public class PlayerInfo
    {
        public long PlayerInfoId { get; set; }
        public Player Player { get; set; }
        public long TotalBets { get; set; }
        public long TotalBetsWon { get; set; }
        public long TotalBetsLost { get; set; }
        public double AmountWon { get; set; }
        public double AmountLost { get; set; }
    }

    public class Player
    {
        public long PlayerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Bet
    {
        public long BetId { get; set; }
        public long PlayerId { get; set; }
        public long EventId { get; set; }
        public byte Type { get; set; }
        public double Amount { get; set; }
    }

    public class Event
    {
        public DateTime KickoffTime { get; set; }
        public long EventId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public float HomeOdds { get; set; }
        public float AwayOdds { get; set; }
        public float DrawOdds { get; set; }
        public byte Result { get; set; }
    }
}
