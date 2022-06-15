using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace notepad_razor.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly NotepadDbContext context;
        private readonly IPasswordHasher<UserModel> passwordHasher;

        public LoginModel(NotepadDbContext _context, IPasswordHasher<UserModel> _passwordHasher)
        {
            context = _context;
            passwordHasher = _passwordHasher;
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public UserModel UserModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await context.Users.FirstOrDefaultAsync(p => p.NickName.Equals(UserModel.NickName));

            if (user is null)
            {
                return Page();
            }

            var verifyPassword = passwordHasher.VerifyHashedPassword(UserModel, user.HashedPassword, UserModel.Password);

            if (verifyPassword == PasswordVerificationResult.Success)
            {
                var claims = new List<Claim>
                {
                    new Claim("ID", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.NickName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Permission),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return LocalRedirect("/");
            }
            else
            {
                return Page();
            }
        }
    }
}
