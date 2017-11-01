using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParPorMobWebApp.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DistrictId { get; set; }

    }
}