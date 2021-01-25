using lottery.Data;
using lottery.Models;
using lottery.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lottery.Services
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext _ctx;
        public MemberService(ApplicationDbContext context)
        {
            _ctx = context;

        }
        public IList<MemberViewModel> GetMembers()
        {
            var members = _ctx.Members.ToList();
            var result = new List<MemberViewModel>();
            foreach(var m in members)
            {
                var mvm = new MemberViewModel();
                mvm.Member = m;

                var dr = _ctx.Draws.FirstOrDefault(x => x.Winner == m);
                if (dr != null && dr.Winner!=null)
                {
                    mvm.HasWon = true;
                    mvm.Wondate = dr.DrawDate;
                }
                

                result.Add(mvm);
            }
            
            return result;
        }

    }
}
