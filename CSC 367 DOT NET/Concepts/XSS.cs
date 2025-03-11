// Here’s a simpler and more concise version of the code to prevent XSS in a C# (ASP.NET) environment:

// Vulnerable Code (Without Validation)
// <!-- Default.aspx -->
<form action="Submit.aspx" method="post">
    <input type="text" name="comment" placeholder="Write a comment">
    <button type="submit">Post</button>
</form>
// Submit.aspx.cs (Vulnerable)
protected void Page_Load(object sender, EventArgs e)
{
    if (Request.HttpMethod == "POST")
    {
        string userComment = Request.Form["comment"];
        Response.Write(userComment); // Vulnerable to XSS
    }
}

// Fixed Code (Preventing XSS)
// Submit.aspx.cs (Fixed)
protected void Page_Load(object sender, EventArgs e)
{
    if (Request.HttpMethod == "POST")
    {
        string userComment = Request.Form["comment"];
        string sanitizedComment = Server.HtmlEncode(userComment); // Sanitize input
        Response.Write(sanitizedComment); // Display sanitized input
    }
}
// Key Points:
// Server.HtmlEncode: Encodes HTML tags like <script> to their safe representation (&lt;script&gt;), preventing XSS.
// This concise version ensures that user input is sanitized before displaying it, preventing XSS attacks.