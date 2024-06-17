using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaBabelAPI.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = ""!;
        public string IsoCode { get; set; } = ""!;
        public string Population { get; set; } = ""!;
        public required IList<Hotel> Hotels { get; set; } = new List<Hotel>();
        public required IList<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
