using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollectVoters.Data;
using CollectVoters.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CollectVoters.DTO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace CollectVoters.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class FriendsController : Controller
    {
        private readonly ILogger<FriendsController> _logger;
        private readonly Db_usersContext _context;

        public FriendsController(Db_usersContext context, ILogger<FriendsController> logger)
        {
            _context = context;
            _logger = logger;
        }

                
        // GET: Friends
        public async Task<IActionResult> Index(string nothing)
        {
            string userName;
            // userName=(string)TempData["userName"];
            userName = User.Identity.Name;
            
            var db_usersContext = _context.Friend.Include(f => f.City).Include(f => f.District).Include(f => f.FieldActivity).Include(f => f.PollingStation).Include(f => f.User).
                                    Where(f => f.User.UserName.Equals(userName)); 
            return View(await db_usersContext.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("UserName", "Password", "ReturnUrl")] LoginModel loginViewModel)
        {
            string userName = loginViewModel.UserName;

            var db_usersContext = _context.Friend.Include(f => f.City).Include(f => f.District).Include(f => f.FieldActivity).Include(f => f.PollingStation).Include(f => f.User).
                                    Where(f => f.User.UserName.Equals(userName));
            return View(await db_usersContext.ToListAsync());
        }


        // GET: Friends/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.City, "IdCity", "Name");
            ViewData["DistrictId"] = new SelectList(_context.District, "IdDistrict", "Name");
            ViewData["FieldActivityId"] = new SelectList(_context.Fieldactivity, "IdFieldActivity", "Name");
            ViewData["PollingStationId"] = new SelectList(_context.PollingStation, "IdPollingStation", "Name");
            ViewData["UserId"] = new SelectList(_context.User, "IdUser", "UserName");
            return View();
        }

        // POST: Friends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFriend,FamilyName,Name,PatronymicName,DateBirth,CityId,Street,House,Apartment,Telephone,DistrictId,PollingStationId,Organization,FieldActivityId,PhoneNumberResponsible,DateRegistrationSite,VotingDate,Voter,Description,UserId")] Friend friend)
        {
            List<Friend> searchFriend = _context.Friend.Where(frnd => frnd.Name.Equals(friend.Name) && frnd.FamilyName.Equals(friend.FamilyName) && frnd.PatronymicName.Equals(friend.PatronymicName) && frnd.DateBirth.Value.Date == friend.DateBirth.Value.Date).ToList();

            if (searchFriend.Count==0)
            {
               
                if (ModelState.IsValid)
                {
                    long idUserSave = _context.User.Where(u => u.UserName.Equals(User.Identity.Name)).FirstOrDefault().IdUser;
                    friend.UserId = idUserSave;

                    _context.Add(friend);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CityId"] = new SelectList(_context.City, "IdCity", "Name", friend.CityId);
                ViewData["DistrictId"] = new SelectList(_context.District, "IdDistrict", "Name", friend.DistrictId);
                ViewData["FieldActivityId"] = new SelectList(_context.Fieldactivity, "IdFieldActivity", "Name", friend.FieldActivityId);
                ViewData["PollingStationId"] = new SelectList(_context.PollingStation, "IdPollingStation", "Name", friend.PollingStationId);
                ViewData["UserId"] = new SelectList(_context.User, "IdUser", "UserName", friend.UserId);
                return View(friend);
            }
            else return Content("Данный пользователь уже был внесен в списки ранее!");
        }

        // GET: Friends/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friend.FindAsync(id);
            if (friend == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "IdCity", "Name", friend.CityId);
            ViewData["DistrictId"] = new SelectList(_context.District, "IdDistrict", "Name", friend.DistrictId);
            ViewData["FieldActivityId"] = new SelectList(_context.Fieldactivity, "IdFieldActivity", "Name", friend.FieldActivityId);
            ViewData["PollingStationId"] = new SelectList(_context.PollingStation, "IdPollingStation", "Name", friend.PollingStationId);
            ViewData["UserId"] = new SelectList(_context.User, "IdUser", "UserName", friend.UserId);
            return View(friend);
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdFriend,FamilyName,Name,PatronymicName,DateBirth,CityId,Street,House,Apartment,Telephone,DistrictId,PollingStationId,Organization,FieldActivityId,PhoneNumberResponsible,DateRegistrationSite,VotingDate,Voter,Description,UserId")] Friend friend)
        {

            if (id != friend.IdFriend)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                DateTime dateEmpty = new DateTime();
                if (!friend.Name.Equals("") && !friend.FamilyName.Equals("") && friend.DateBirth != dateEmpty)
                {
                    List<Friend> searchFriend = _context.Friend.Where(frnd => frnd.Name.Equals(friend.Name) && frnd.FamilyName.Equals(friend.FamilyName) && frnd.PatronymicName.Equals(friend.PatronymicName) && frnd.DateBirth.Value.Date == friend.DateBirth.Value.Date && frnd.IdFriend != friend.IdFriend).ToList();

                    if (searchFriend.Count == 0)
                    {

                        long idUserSave = _context.User.Where(u => u.UserName.Equals(User.Identity.Name)).FirstOrDefault().IdUser;
                        friend.UserId = idUserSave;

                        try
                        {
                            _context.Update(friend);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!FriendExists(friend.IdFriend))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                        return RedirectToAction(nameof(Index));

                    }
                    else return Content("Данный пользователь уже присутствует в списках!");
                }
                else return Content("Не все обязательные поля были заполнены!");
            }
            ViewData["CityId"] = new SelectList(_context.City, "IdCity", "Name", friend.CityId);
            ViewData["DistrictId"] = new SelectList(_context.District, "IdDistrict", "Name", friend.DistrictId);
            ViewData["FieldActivityId"] = new SelectList(_context.Fieldactivity, "IdFieldActivity", "Name", friend.FieldActivityId);
            ViewData["PollingStationId"] = new SelectList(_context.PollingStation, "IdPollingStation", "Name", friend.PollingStationId);
            ViewData["UserId"] = new SelectList(_context.User, "IdUser", "UserName", friend.UserId);
            return View(friend);
        }

        // GET: Friends/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friend
                .Include(f => f.City)
                .Include(f => f.District)
                .Include(f => f.FieldActivity)
                .Include(f => f.PollingStation)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.IdFriend == id);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var friend = await _context.Friend.FindAsync(id);
            _context.Friend.Remove(friend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendExists(long id)
        {
            return _context.Friend.Any(e => e.IdFriend == id);
        }

        //public IActionResult LogOff()
        //{
        //    HttpContext.SignOutAsync("Cookie");
        //    return Redirect("/Home/Index");
        //}
    }
}
