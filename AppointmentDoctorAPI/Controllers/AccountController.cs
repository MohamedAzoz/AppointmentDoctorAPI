using AppointmentDoctorAPI.DTOs;
using AppointmentDoctorAPI.Models;
using AppointmentDoctorAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppointmentDoctorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IPatient patient;
        private readonly IDentist dentist;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<AppUser> userManager,IPatient patient
                                        ,IDentist dentist, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.patient = patient;
            this.dentist = dentist;
            this.configuration = configuration;
        }

        [HttpPost("RegisterDoctor")]
        public async Task<IActionResult> RegisterDoctor(DoctorDTO doctorDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = doctorDTO.UserName;
                user.Email = doctorDTO.Email;
                Dentist dent = new Dentist();
                dent.ImgURL=doctorDTO.ImgURL;
                dent.ClinicAddress = doctorDTO.ClinicAddress;
                dent.Specialization=doctorDTO.Specialization;
                //===> Search to How Add Role in Web API

                IdentityResult result =
                    await userManager.CreateAsync(user, doctorDTO.Password);
                if (result.Succeeded)
                {
                    dent.UserId = (await userManager.FindByEmailAsync(user.Email)).Id;
                    dentist.Add(dent);
                    dentist.Save();
                    await userManager.AddToRoleAsync(user, "Doctor");
                    return Ok("Created");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Password", item.Description);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("RegisterPatient")]
        public async Task<IActionResult> RegisterPatient([FromBody]PatientDTO patientDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = patientDTO.UserName;
                user.Email = patientDTO.Email;
                Patient patient1 = new Patient();
                patient1.DateOfBirth=patientDTO.DateOfBirth;
                //===> Search to How Add Role in Web API
                IdentityResult result =
                    await userManager.CreateAsync(user, patientDTO.Password);
                if (result.Succeeded)
                {
                    patient1.UserId = (await userManager.FindByEmailAsync(user.Email)).Id;
                    patient.Add(patient1);
                    patient.Save();

                    await userManager.AddToRoleAsync(user,"Patient");
                    
                    return Ok("Created");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Password", item.Description);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO userDto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByNameAsync(userDto.UserName);
                if (appUser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(appUser, userDto.Password);
                    if (found)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id));
                        claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));

                        //===> Search to How Add Role in Web API

                        var Roles = await userManager.GetRolesAsync(appUser);
                        foreach (var item in Roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, item));
                        }

                        SymmetricSecurityKey key =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecritKey"]));

                        SigningCredentials signingCred =
                            new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        JwtSecurityToken token = new JwtSecurityToken(
                            issuer: configuration["JWT:IssuerIP"],
                            audience: configuration["JWT:AudienceIP"],
                            claims: claims,
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: signingCred
                            );

                        return Ok(new GenerateTokenDto
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            Expires = DateTime.Now.AddHours(1)
                        });
                    }
                }
                ModelState.AddModelError("userName", "UserName OR Password Is Wrong");
            }
            return BadRequest(ModelState);
        }

    }
}