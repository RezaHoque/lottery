using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lottery.Models.ViewModels
{
    public class MemberViewModel
    {
        public Member Member { get; set; }
        public bool HasWon { get; set; }
        public DateTime Wondate { get; set; }
    }
}
