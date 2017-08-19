using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using XCentium.Test.Utilities;
using XCentium.Test.Web.Models;


namespace XCentium.Test.Web.Controllers
{
    /// <summary>
    /// home page controller
    /// </summary>
    public class HomeController : Controller
    {
        int _maxWordCount = 5, _maxImageCount = 5;
        public HomeController(IOptions<MaxCountsSettings> settings)
        {
            int.TryParse(settings.Value.MaxWordCount, out _maxWordCount);
            int.TryParse(settings.Value.MaxImageCount, out _maxImageCount);
        }
       
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Retrieve "page data" with given URL
        /// </summary>
        /// <param name="model">Data Model, used for both request and response.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(PageDataModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.PageData = (new HtmlParser()).ExtractPageData(model.PageUrl, _maxWordCount, _maxImageCount);
                }
                catch (Exception e)
                {
                    while (e.InnerException != null) e = e.InnerException;
                    ModelState.AddModelError("ServerError", "Error retrieving page data: " + e.Message);
                }
            }
            return View(model);
        }
    }
}
