using System;
using HorasExtra.Data;
using HorasExtra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace HorasExtra.Controllers
{
    public class RequestsController : Controller
    {
        private readonly HorasExtraDBContext _context;
        Sp sp = new Sp();
        public RequestsController(HorasExtraDBContext context)
        {
            _context = context;
        }
        // GET: RequestsControllercs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Request.ToListAsync());
        }


        // GET: RequestsControllercs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request.FirstOrDefaultAsync(m => m.ID_request == id);

            var blogs = _context.Employees.FromSqlRaw($"EXECUTE dbo.GetEmployeeByIDReq {id.ToString()}").ToList();

            request.Employees = blogs;
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: RequestsControllercs/Create
        public ActionResult Create()
        {
            return View();

        }

        // POST: RequestsControllercs/Create
        [HttpPost]
        public JsonResult Create([Bind("ID_request,Operation,Department,CreatedDate,WorkSchedule,ManagerSignature,SupervisorSignature")] Request request)
        {
            request.CreatedDate = DateTime.Now;
            request.UpdatedAt = DateTime.Now;
            return Json(sp.SaveRequest(request));
        }

        // GET: RequestsControllercs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RequestsControllercs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RequestsControllercs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RequestsControllercs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
