using eBilety.Data.Services;
using eBilety.Data.Static;
using eBilety.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBilety.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            this._service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
                return View(actor);

            _service.Add(actor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetById(id);

            if (actorDetails == null)
                return View("NotFound");

            return View(actorDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null)
                return View("NotFound");

            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
                return View(actor);

            await _service.Update(id, actor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null) return View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
