using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AndreAirlineApi2.Model;
using AndreAirlineMVC.Data;

namespace AndreAirlineMVC.Controllers
{
    public class AirportDatasController : Controller
    {
        private readonly AndreAirlineMVCContext _context;

        public AirportDatasController(AndreAirlineMVCContext context)
        {
            _context = context;
        }

        // GET: AirportDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.AirportData.ToListAsync());
        }
    }
}
