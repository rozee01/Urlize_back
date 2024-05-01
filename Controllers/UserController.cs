using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Threading.Tasks;
using Urlize_back.Dtos;
using Urlize_back.Models;

namespace Urlize_back.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UserController (SignInManager<User> sm, UserManager<User> um): ControllerBase
    {
        private readonly UserManager<User> userManager=um;
        private readonly SignInManager<User> signInManager = sm;


        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto user)
        {
            string message = "";
            IdentityResult result = new();
            try
            {
                User user_ = new User()
                {
                    UserName =user.Firstname,
                    Email = user.Email,
                    LastName = user.Lastname,
                    PhoneNumber = user.PhoneNumber,
                };

                result = await um.CreateAsync(user_,user.Password);

                if (!result.Succeeded) return BadRequest(result.Errors);
                message = "Registered successfully";
            }catch (Exception ex)
            {
                return BadRequest("Something when wrong ! "+ ex.Message);   
            }
            return Ok(new { message = message ,result=result});  ;
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(Models.Login login)
        {
            string message = "";
            try
            {
                User user_ = await um.FindByEmailAsync(login.Email);
                if(user_ != null & user_.EmailConfirmed) {
                //confirm the email process
                user_.EmailConfirmed = true;
                }

                var result = await sm.PasswordSignInAsync(user_,login.Password,login.RememberMe,false);

                if (!result.Succeeded) return Unauthorized("check ur credentiels ");
                message = "login in succefull";
            }
            catch (Exception ex)
            {
                return BadRequest("Something when wrong ! " + ex.Message);
            }
            return Ok(new { message = message}); ;
        }
        [HttpGet("LogOut"),Authorize]
        public async Task<ActionResult> LogoutUser()
        {
            string message = "You are free to go !";
            try
            {
                await signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok(new { message = message}); 

        }
    }
}
