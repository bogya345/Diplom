using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

//using hod_back.DAL.Models;
//using hod_back.DAL.Models.Views;
//using hod_back.DAL.Models.ToRecieve;
//using hod_back.DAL.Models.ToSend;
//using hod_back.DAL.Models.ToParse;

//using hod_back.DAL;
//using hod_back.DAL.Contexts;

//using hod_back.Services.Excel;
using Microsoft.AspNetCore.Identity;
using hod_back.DAL;
using hod_back.Dto;
using AutoMapper;
using hod_back.Models;
using hod_back.Model;

namespace hod_back.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdminController : Controller
    {
        private UnitOfWork _unit;
        private IMapper _mapper;

        public AdminController(UnitOfWork unit, IMapper mapper, IHostingEnvironment hostEnv)
        {
            this._unit = unit;
            this._mapper = mapper;
        }

        [HttpGet("get/mapper/subDeps")]
        public async Task<MapSudDep> GetMapSubDep()
        {
            var tmp1 = await _unit.Subjects.GetManyWithIncludeAsync(x => x.SubId > 0);
            var res1 = _mapper.Map<IEnumerable<SubDepDto>>(tmp1);

            var tmp2 = await _unit.Departments.GetManyAsync(x => x.DepTId == 6);
            var res2 = _mapper.Map<IEnumerable<DepsDto>>(tmp2);

            var tmp3 = await _unit.AcPlanDeps.GetAllAsync();
            var res3 = _mapper.Map<IEnumerable<DepDepDto>>(tmp3);

            var res = new MapSudDep { subDeps = res1.ToArray(), deps = res2.ToArray(), depDep = res3.ToArray() };
            return res;
        }

        [HttpPost("post/mapper/depDeps")]
        public JsonResult PostDepDep([FromBody] DepDepModel[] model)
        {
            if (model == null || model.Length == 0) { return Json("Изменений не обнаруженно"); }

            var tmp = _mapper.Map<IEnumerable<AcPlanDep>>(model);

            _unit.AcPlanDeps.UpdateRange(tmp.ToArray());

            return Json("Изменения сохранены.  Обновление...");
        }

        [HttpPost("post/mapper/subDeps")]
        public JsonResult PostSubDep([FromBody] SubDepModel[] model)
        {
            if (model == null || model.Length == 0) { return Json("Изменений не обнаруженно"); }

            var tmp = _mapper.Map<IEnumerable<AcPlanDep>>(model);

            _unit.AcPlanDeps.UpdateRange(tmp.ToArray());

            return Json("Изменения сохранены");
        }

        //RoleManager<IdentityRole> _roleManager;
        //UserManager<User> _userManager;

        //public AdminController(RoleManager<IdentityRole> roleManager, UserManager<UserAuth> userManager)
        //{
        //    _roleManager = roleManager;
        //    //_userManager = userManager;
        //}

        //public IActionResult Index() => View(_roleManager.Roles.ToList());

        //public IActionResult Create() => View();

        //[HttpPost]
        //public async Task<IActionResult> Create(string name)
        //{
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }
        //    }
        //    return View(name);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    IdentityRole role = await _roleManager.FindByIdAsync(id);
        //    if (role != null)
        //    {
        //        IdentityResult result = await _roleManager.DeleteAsync(role);
        //    }
        //    return RedirectToAction("Index");
        //}

        //public IActionResult UserList() => View(_userManager.Users.ToList());

        //public async Task<IActionResult> Edit(string userId)
        //{
        //    // получаем пользователя
        //    User user = await _userManager.FindByIdAsync(userId);
        //    if (user != null)
        //    {
        //        // получем список ролей пользователя
        //        var userRoles = await _userManager.GetRolesAsync(user);
        //        var allRoles = _roleManager.Roles.ToList();
        //        ChangeRoleViewModel model = new ChangeRoleViewModel
        //        {
        //            UserId = user.Id,
        //            UserEmail = user.Email,
        //            UserRoles = userRoles,
        //            AllRoles = allRoles
        //        };
        //        return View(model);
        //    }

        //    return NotFound();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(string userId, List<string> roles)
        //{
        //    // получаем пользователя
        //    User user = await _userManager.FindByIdAsync(userId);
        //    if (user != null)
        //    {
        //        // получем список ролей пользователя
        //        var userRoles = await _userManager.GetRolesAsync(user);
        //        // получаем все роли
        //        var allRoles = _roleManager.Roles.ToList();
        //        // получаем список ролей, которые были добавлены
        //        var addedRoles = roles.Except(userRoles);
        //        // получаем роли, которые были удалены
        //        var removedRoles = userRoles.Except(roles);

        //        await _userManager.AddToRolesAsync(user, addedRoles);

        //        await _userManager.RemoveFromRolesAsync(user, removedRoles);

        //        return RedirectToAction("UserList");
        //    }

        //    return NotFound();
        //}

    }

    //[HttpGet("feedback")

}