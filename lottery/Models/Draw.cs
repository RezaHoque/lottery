using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lottery.Models
{
    public class Draw
    {
        public string Id { get; set; }
        public DateTime DrawDate { get; set; }
        public Member Winner { get; set; }

    }
}
