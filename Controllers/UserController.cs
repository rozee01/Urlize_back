using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Threading.Tasks;
using Urlize_back.Dtos;
using Urlize_back.Models;
using Urlize_back.Services;

namespace Urlize_back.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UserController (SignInManager<User> sm, UserManager<User> um): ControllerBase
    {
        private readonly IEmailService _emailService;

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
                await um.AddToRoleAsync(user_, "Business Owner");

                await SendConfirmationEmail(user.Email, user_);
                if (!result.Succeeded) return BadRequest(result.Errors);
                message = "Registered successfully";
            }catch (Exception ex)
            {
                return BadRequest("Something when wrong ! "+ ex.Message);   
            }
            return Ok(new { message = message ,result=result});  ;
        }


        private async Task SendConfirmationEmail(string? email, User? user)
        {
            var token = await um.GenerateEmailConfirmationTokenAsync(user);
            //redirect the user to the confirm page 
            var confirmationLink = $"http://localhost:3000/check?UserId={user.Id}&Token={token}";
            await _emailService.SendEmailAsync(email, "Confirm Your Email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>;.", true);
        }


        public async Task<String> ConfirmEmail(string userId, string token)
        {
            var user = await um.FindByIdAsync(userId);
            if (userId == null || token == null)
            {
                return "Link expired";
            }
            else if (user == null)
            {
                return "User not Found";
            }
            else
            {
                token = token.Replace(" ", "+");
                var result = await um.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return "Thank you for confirming your email";
                }
                else
                {
                    return "Email not confirmed";
                }

            }
        }


        [HttpPost("Login")]
        public async Task<ActionResult> Login(Models.Login login)
        {
            string message = "";
            try
            {
                User user_ = await um.FindByEmailAsync(login.Email);
                if(user_ != null & user_.EmailConfirmed) {
                    return Unauthorized("check ur Email and verify ur account !");
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
