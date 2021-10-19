using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Tinder.Data.Entities;
using Tinder.Service.Abstract;
using TinderMVC.Models;

namespace TinderMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMatchesService _matchesService;
        public HomeController(IMatchesService matchesService, IUserService userService)
        {
            _matchesService = matchesService;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetRemainingUsers());
        }

        public async Task<IActionResult> Like(User user)
        {
            await _matchesService.LikeToUser(user);
            return RedirectToAction("Index", "Home");
        }

        public async ValueTask<IActionResult> UnLike(User user)
        {
            await _matchesService.DisLikeToUser(user);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> GetMatches()
        {
            return View(await _userService.GetUserMatches());
        }

    }
}