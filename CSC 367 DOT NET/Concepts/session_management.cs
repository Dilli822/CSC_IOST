using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult SetSession() 
    {
        HttpContext.Session.SetString("User", "JohnDoe");
        return Content("Session Set");
    }

    public IActionResult GetSession() 
    {
        string user = HttpContext.Session.GetString("User") ?? "No Session";
        return Content($"User: {user}");
    }

    public IActionResult ClearSession() 
    {
        HttpContext.Session.Clear();
        return Content("Session Cleared");
    }
}
