using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lottery.Models.ViewModels
{
    public class DrawViewModel
    {
        public List<MemberViewModel> Members { get; set; }
        public int TotalMembers { get; set; }
        public int TotalDraws { get; set; }
    }
}
