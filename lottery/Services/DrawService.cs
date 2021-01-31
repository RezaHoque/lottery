using lottery.Data;
using lottery.Models;
using lottery.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lottery.Services
{
    public class DrawService : IDrawService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMemberService _memberService;

        public DrawService(ApplicationDbContext context,IMemberService memberService)
        {
            _ctx = context;
            _memberService = memberService;
        }
        public MemberViewModel Draw()
        {
            var random = new Random();

            var list = new List<string>();

            list = _memberService.GetMembers().Where(x=>!x.HasWon).Select(x => x.Member.Name).ToList();
            if (list.Any())
            {
                int index = random.Next(list.Count);

                var winner = list[index];

                var wn = _memberService.GetMembers().Where(x => x.Member.Name == winner).FirstOrDefault();

                var currentMonth = DateTime.Now.Month;
                var lastDrawMonth = _ctx.Draws.OrderByDescending(x => x.DrawDate.Month).FirstOrDefault().DrawDate.Month;

               // if (currentMonth > lastDrawMonth)
                //{
                    var draw = new Draw();
                    draw.Id = Guid.NewGuid().ToString();
                    draw.DrawDate = DateTime.Now;
                    draw.Winner = wn.Member;

                    _ctx.Draws.Add(draw);
                    _ctx.SaveChanges();
                //}

                
                return wn;
            }
            return new MemberViewModel();
            

            
        }

        public DrawViewModel InitiateDraw()
        {
            var result = new DrawViewModel();
            result.Members = (List<MemberViewModel>)_memberService.GetMembers();
            result.TotalMembers = result.Members.Count();
            result.TotalDraws = _ctx.Draws.Count();

            return result;
        }
    }
}
