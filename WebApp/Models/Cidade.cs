using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.models
{
    public class Cidade
    {        
        public string Name { get; set; }
        public Double Temp { get; set; }

        public DateTime Date { get; set; }

        public Cidade( string Name, Double Temp, DateTime Date)
        {           
            this.Name = Name;
            this.Temp = Temp;
            this.Date = Date;
        }

    }
}
