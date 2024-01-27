using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECAN_CRF.Models
{
    public class General
    {
        public List<Centers> Centers { get; set; }
        public List<Events> events { get; set; }
        public List<Schools> schools { get; set; }
        public List<Sponsers> sponsers { get; set; }
        public List<Studens> studens { get; set; }
        public List<Users> Users { get; set; }
    }
}
