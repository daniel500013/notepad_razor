using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace notepad_razor.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly NotepadDbContext context;
        private readonly IPasswordHasher<UserModel> passwordhasher;

        public RegisterModel(NotepadDbContext _context, IPasswordHasher<UserModel> _passwordhasher)
        {
            context = _context;
            passwordhasher = _passwordhasher;
        }

        public void OnGet()
        {
            
        }

        [BindProperty]
        public UserModel UserModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var emailExist = await context.Users.FirstOrDefaultAsync(x => x.Email == UserModel.Email);
                var userExist = await context.Users.FirstOrDefaultAsync(x => x.NickName == UserModel.NickName);
                
                if (UserModel == null)
                {
                    ModelState.AddModelError("RegisterError", "Invalid login attempt");
                    return Page();
                }

                if (emailExist != null)
				{
                    ModelState.AddModelError("RegisterError", "Invalid email");
                    return Page();
                }

                if (userExist != null)
                {
                    ModelState.AddModelError("RegisterError", "Invalid username");
                    return Page();
                }

                var NameIdentifier = (context.Users.ToList().Count + 1).ToString();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, NameIdentifier),
                    new Claim(ClaimTypes.Name, UserModel.NickName),
                    new Claim(ClaimTypes.Email, UserModel.Email),
                    new Claim(ClaimTypes.Role, UserModel.Permission),
                    new Claim("Class", UserModel.UserClass.ToString()),
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

                UserModel.HashedPassword = passwordhasher.HashPassword(UserModel, UserModel.Password);

                context.Add(UserModel);
                await context.SaveChangesAsync();

                return RedirectToPage("/Auth/RegisterComplete", UserModel);
            }
            else
            {
                return Page();
            }
        }
    }
}
