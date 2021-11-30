using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat1
{
    public class Piano
    {
        private string name;        
        private int production;
        private DateTime founded;
        private string logo;
        private string detailed;


        public string Name { get => name; set => name = value; }
        public int Production { get => production; set => production = value; }
        public DateTime Founded { get => founded; set => founded = value; }
        public string Logo { get => logo; set => logo = value; }
        public string Detailed { get => detailed; set => detailed = value; }


        public Piano(string name, int production, DateTime founded, string logo, string detailed)
        {
            Name = name;            
            Production = production;
            Founded = founded;
            Logo = logo;
            Detailed = detailed;
        }

        public Piano ()
        {

        }

    }
}
