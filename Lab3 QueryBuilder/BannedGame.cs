﻿using System;
using Lab3_QueryBuilder;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_QueryBuilder
{
    internal class BannedGame : IClassModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Series { get; set; }
        public string Country { get; set; }
        public string Details { get; set; }


        public BannedGame() 
        {

        }

        public BannedGame(int id, string title, string series, string country, string details)
        {
            Id = id;
            Title = title;
            Series = series;
            Country = country;
            Details = details;
        }

        public override string ToString()
        {
            return $"In {Country} the game {Title} was {Details}";
        }


    }
}
