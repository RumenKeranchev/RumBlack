﻿namespace RB.Data.DbModels.Music
{
    public class BandConcert
    {
        public int BandId { get; set; }

        public Band Band { get; set; }

        public int ConcertId { get; set; }

        public Concert Concert { get; set; }
    }
}