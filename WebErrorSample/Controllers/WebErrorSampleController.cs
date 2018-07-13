namespace WebErrorSample.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using WebErrorSample.DAL;
    using WebErrorSample.Models;

    public class WebErrorSampleController : Controller
    {
        [Route("")]
        public JsonResult Get()
        {
            using (var context = new WebErrorSampleContext())
            {
                //var parentsFirstChildWorking =
                //    context.Parents
                //        .Include(x => x.Children)
                //        .ThenInclude(x => x.Toy.Category)
                //        .ToList() // ToList added, execution succeeds
                //        .Select(x => new ParentFirstChildClass
                //        {
                //            Id = x.ParentEntityId,
                //            Name = x.ParentName,
                //            FirstChildName = x.Children.First().ChildName,
                //            ChildsToy = x.Children.First().Toy.ToyName,
                //            ChildsToyCategory = x.Children.First().Toy.Category.CategoryName
                //        }).ToList();
                        
                var parentsFirstChildBroken =
                    context.Parents
                        .Include(x => x.Children)
                        .ThenInclude(x => x.Toy.Category)
                        .Select(x => new ParentFirstChildClass
                        {
                            Id = x.ParentEntityId,
                            Name = x.ParentName,
                            FirstChildName = x.Children.First().ChildName, // Works
                            ChildsToy = x.Children.First().Toy.ToyName, // Works
                            ChildsToyCategory = x.Children.First().Toy.Category.CategoryName // Breaks
                        }).ToList();

                //return Json(parentsFirstChildWorking);
                return Json(parentsFirstChildBroken);
            }
        }
    }
}
