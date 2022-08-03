using DependencyInjection.Models;
using DependencyInjection.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        //private ProductSum _productSum;

        public HomeController(IRepository repository/*, ProductSum productSum*/)
        {
            _repository = repository;
            //_productSum = productSum;
        }

        public IActionResult Index([FromServices] ProductSum _productSum)
        {
            //ViewBag.Total = _productSum.Total;

            ViewBag.HomeControllerGuid = _repository.ToString();
            ViewBag.TotalGuid = _productSum.Repository.ToString();

            return View(_repository.Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}