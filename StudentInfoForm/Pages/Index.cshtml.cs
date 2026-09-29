using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
 
namespace StudentInfoForm.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            // This runs when the page first loads
        }
 
        public IActionResult OnPost()
        {
            // This runs when the form is submitted
            string studentName = Request.Form["StudentName"];
            string email = Request.Form["Email"];
            string phone = Request.Form["Phone"];
            string major = Request.Form["Major"];
            string agreeToTerms = Request.Form["AgreeToTerms"];
 
            // Validate required fields
            if (string.IsNullOrEmpty(studentName) || 
                string.IsNullOrEmpty(email) || 
                string.IsNullOrEmpty(major))
            {
                ModelState.AddModelError("", "Please fill in all required fields.");
                return Page();
            }
 
            // Check if terms were agreed to
            if (string.IsNullOrEmpty(agreeToTerms))
            {
                ModelState.AddModelError("", "You must agree to the terms.");
                return Page();
            }
 
            // If validation passes, show success message
            ViewData["Success"] = true;
            ViewData["StudentName"] = studentName;
 
            return Page();
        }
    }
}