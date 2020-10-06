﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
{
    class InfTemp
    {
        public class coord
        {
            public double lon { get; set; }
            public double lat { get; set; }

        }
        public class wheater
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }

        }
        public class main
        {
            public double Temp { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }


        }

        public class wind
        {
            public double speed { get; set; }

        }

        public class sys
        {
            public string country { get; set; }

        }

        public class root
        {
            public string name { get; set; }
            public sys sys { get; set; }
            public double dt { get; set; }
            public wind wind { get; set; }
            public main main { get; set; }
            public List<InfTemp> InfTempList { get; set; }

            public coord coordinate { get; set; }


        }
    }
}
