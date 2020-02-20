using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Models;
using DatingApp.API.Contracts;
using DatingApp.API.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

//using ResponseFormattingSample.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatingApp.API.Controllers {
  [Route ("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase {
    private readonly IAuthRepository _repo;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;

    public AuthController (IAuthRepository repo, IMapper mapper, IConfiguration config) {
      _repo = repo;
      _config = config;
      _mapper = mapper;
    }

    // POST api/<controller>
    [HttpPost ("register")]
    public async Task<IActionResult> Register (UserForRegisterDto userForRegisterDto) {
      userForRegisterDto.Username = userForRegisterDto.Username.ToLower ();
      if (await _repo.UserExists (userForRegisterDto.Username))
        return BadRequest ("Username already exists");

      var userToCreate = _mapper.Map<User> (userForRegisterDto);
      var createdUser = await _repo.Register (userToCreate, userForRegisterDto.Password);
      var userToReturn = _mapper.Map<UserForDetailedDto> (createdUser);
      return CreatedAtRoute ("GetUser", new { controller = "Users", id = createdUser.Id }, userToReturn);
    }

    [HttpPost ("login")]
    public async Task<IActionResult> Login (UserForLoginDto userForLoginDto) {
         
      if (userForLoginDto == null)
        return BadRequest ("Null request parmeters");

      var userRepo = await _repo.Login (userForLoginDto.Username.ToLower (), userForLoginDto.Password);
      if (userRepo == null) {
        return Unauthorized ();
      }

      var claims = new [] {
        new Claim (ClaimTypes.NameIdentifier, userRepo.Id.ToString ()),
        new Claim (ClaimTypes.Name, userRepo.Username)
      };
      var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (_config.GetSection ("AppSettings:Token").Value));
      var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha512Signature);

      var tokenDescriptor = new SecurityTokenDescriptor {
        Subject = new ClaimsIdentity (claims),
        Expires = DateTime.Now.AddDays (2),
        SigningCredentials = creds
      };

      var tokenHandler = new JwtSecurityTokenHandler ();
      var token = tokenHandler.CreateToken (tokenDescriptor);
      var user = _mapper.Map<UserForListDto> (userRepo);
      return Ok (new {
        token = tokenHandler.WriteToken (token),
          user
      });
    }
  }
}