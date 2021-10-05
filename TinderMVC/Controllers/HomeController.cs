using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tinder.Data.Context;
using Tinder.Data.Entities;
using Tinder.Repository.Abstract;
using Tinder.Service.Abstract;
using TinderMVC.Models;
using X.PagedList;

namespace GirisKayit.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMatchesService _matchesService;
        private readonly IUnitOfWorkPattern _unitOfWork;
        public HomeController(IUnitOfWorkPattern unitOfWork, IMatchesService matchesService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _matchesService = matchesService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var login = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var query1 = (await _userService.GetUserWithMatches()).Where(x => x.Id != login);
            var query2 = (await _matchesService.GetAll()).Where(y => y.PersonId == login);
            List<UserModel> userModels = new List<UserModel>();
            foreach (var item in query1)
            {
                UserModel userModel = new UserModel
                {
                    UserId = item.Id,
                    UserName = item.UserName,
                    BirthDate = item.BirthDate,
                    Description = item.Description,
                };

                userModels.Add(userModel);
            }
            foreach (var item1 in query2)
            {
                var check = userModels.FirstOrDefault(x => x.UserId == item1.LikedPerson);
                if (check != null)
                {
                    userModels.Remove(check);
                }
            }
            return View(userModels.ToPagedList(page, 1));
        }

        public async Task<IActionResult> Like(Matches matches, User userLike)
        {
            var login = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userLikeId = await _userService.GetById(userLike.Id);
            matches.PersonId = login;
            matches.LikedPerson = userLikeId.Id;
            matches.Status = true;
             _matchesService.Add(matches);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> UnLike(User userLike, Matches matches)
        {

            var login = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userLikeId = await _userService.GetById(userLike.Id);
            matches.PersonId = login;
            matches.LikedPerson = userLikeId.Id;
             _matchesService.Add(matches);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Matches(ViewModel viewModel)
        {
            var login = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var q = (await _matchesService.GetMatchesWithUser()).Where(y => y.LikedPerson == login && y.Status == true);
            var query2 = (await _matchesService.GetMatchesWithUser()).Where(y => y.PersonId == login && y.Status == true);
            List<ViewModel> listViewModels = new List<ViewModel>();
            foreach (var item in q)
            {
                foreach (var item1 in query2)
                {
                    if (item1.LikedPerson == item.PersonId)
                    {
                        viewModel = new ViewModel
                        {
                            PersonId = login,
                            LikedPersonId = item.User.Id,
                            LikedPersonName = item.User.UserName
                        };
                        listViewModels.Add(viewModel);
                    }
                }
            }
            return View(listViewModels.ToPagedList(1, 10));
        }

    }
}