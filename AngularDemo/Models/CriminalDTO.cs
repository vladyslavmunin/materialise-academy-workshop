using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularDemo.Models
{
    public class CriminalDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Reward { get; set; }
    }
}