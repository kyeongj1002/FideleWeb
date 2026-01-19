using Microsoft.AspNetCore.Mvc;

namespace FideleWeb.Controllers
{
    public class AccountController : Controller
    {
        // 로그인 화면 보여주기 (GET)
        public IActionResult Login()
        {
            return View();
        }

        // 로그인 버튼 눌렀을 때 처리 (POST) - 나중에 구현 예정
        [HttpPost]
        public IActionResult Login(string loginId, string password)
        {
            // 일단은 무조건 메인으로 통과시키기 (껍데기)
            return RedirectToAction("Index", "Home");
        }
    }
}
