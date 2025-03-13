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

// RAZOR SYNTAX VIEW 

@page
@inject Microsoft.Extensions.Caching.Memory.IMemoryCache Cache
@using Microsoft.AspNetCore.Http

@{
    // 1️⃣ Store values
    Context.Session.SetString("User", "JohnDoe");
    Response.Cookies.Append("Email", "jSohn@example.com", new CookieOptions { Expires = DateTimeOffset.Now.AddMinutes(10) });
    Cache.Set("Message", "Hello from Cache!", TimeSpan.FromMinutes(5));

    // 2️⃣ Retrieve values
    var user = Context.Session.GetString("User");
    var email = Context.Request.Cookies["Email"];
    var message = Cache.Get<string>("Message");

    // 3️⃣ Hardcoded Deletion (Deletes on page load)
    Context.Session.Remove("User");  // Delete session
    Response.Cookies.Delete("Email"); // Delete cookie
    Cache.Remove("Message"); // Delete cache
}

<h2>Session, Cookie & Caching Example</h2>

<p><strong>Session:</strong> @(user ?? "No Session Data")</p>
<p><strong>Cookie:</strong> @(email ?? "No Cookie Data")</p>
<p><strong>Cache:</strong> @(message ?? "No Cache Data")</p>
