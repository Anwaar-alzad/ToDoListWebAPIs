using AutoMapper;
using DailyPilot.BLL.DTOs;
using DailyPilot.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace DailyPilot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //this one is used for Registering new user
        private readonly UserManager<ApplicationUser> _userManager;
        //used for authenticate user information
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IMapper _mapper;
  
        //for now i'll comment this so later i'll use it 
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //, SignInManager<ApplicationUser> signInManager
        public AuthController(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _mapper = mapper;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDto dto)
        {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
           
            //take the param dto and map it to ApplicationUser
            var user = _mapper.Map<ApplicationUser>(dto);

            if (user == null)
            {
                return BadRequest("User data is null");
            }
            //this will create a new user in asp.net identity database 
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                return Ok("User registered successfully");
            }
            return BadRequest(result.Errors);
        }

    }

}
