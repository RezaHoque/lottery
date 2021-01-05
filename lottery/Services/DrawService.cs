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
            int index = random.Next(list.Count);

            var winner= list[index];

            var wn= _memberService.GetMembers().Where(x => x.Member.Name == winner).FirstOrDefault();

            var draw = new Draw();
            draw.Id = Guid.NewGuid().ToString();
            draw.DrawDate = DateTime.Now;
            draw.Winner = wn.Member;

            _ctx.Draws.Add(draw);
            _ctx.SaveChanges();

            return wn;
        }
    }
}
