using Microsoft.AspNetCore.Mvc;
using UserRepository.Repository;
using UserRepository.Abstract;
using UserRepository.Models;

namespace Mini_Project.Controllers
{
    public class UserInfoController : Controller
    {
        IUserRepo _repo = new UserRepo();
        public IActionResult Index()
        {
            List<UserDatum> lst = _repo.GetUser();
            return View(lst);
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(UserDatum us)
        {
            string msg = _repo.InsertUserData(us);
            if (msg.Equals("Success"))
                return RedirectToAction("Index");
            else
                ViewBag.Info = "Data not saved,try again later";
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            UserDatum data = _repo.GetIdOnID(id);
            
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(UserDatum us)
        {
            string msg = _repo.UpdateUserData(us);
            if (msg.Equals("Success"))
                return RedirectToAction("Index");
            else
                ViewBag.Info = "Data not saved,try again later";
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            string msg = _repo.DeleteUserData(id);
            if (msg.Equals("Success"))
                return RedirectToAction("Index");
            else
                ViewBag.Info = "Data not saved,try again later";
            return View();
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            UserDatum data = _repo.GetIdOnID(id);
           

            return View(data);
        }
    }
}
