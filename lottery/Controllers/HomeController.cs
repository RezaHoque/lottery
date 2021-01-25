using lottery.Models;
using lottery.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace lottery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemberService _memberService;
        private readonly IDrawService _drawService;

        public HomeController(ILogger<HomeController> logger,IMemberService memberService,IDrawService drawService)
        {
            _logger = logger;
            _memberService = memberService;
            _drawService = drawService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Draw()
        {
            var members = _drawService.InitiateDraw();

            return View(members);
        }
        public IActionResult GetDrawResult()
        {
            var result = _drawService.Draw();
           
            if(result.Member!=null && !string.IsNullOrEmpty(result.Member.Name))
            {
                return Ok(result);
            }
            return Ok("finished");

          
  
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
