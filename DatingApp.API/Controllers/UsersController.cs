using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Contracts;
using DatingApp.API.Dtos;
using DatingApp.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers {

[ServiceFilter(typeof(LogUserActivity))]
  [Authorize]
  [Route ("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase {
    private readonly IRepository _repo;
    private readonly IMapper _mapper;
    public UsersController (IRepository repo, IMapper mapper) {
      _mapper = mapper;
      _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers () {
      var users = _mapper.Map<IEnumerable<UserForListDto>> (await _repo.GetUsers ());
      return Ok (users);
    }

    [HttpGet ("{id}", Name = "GetUser")]
    public async Task<IActionResult> GetUser (int id) {
      var user = _mapper.Map<UserForDetailsDto> (await _repo.GetUser (id));
      return Ok (user);
    }

    [HttpPut ("{id}")]
    public async Task<IActionResult> UpdateUser (int id, UserForUpdateDto userForUpdateDto) {
      if (id != int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value))
        return Unauthorized ();

      var userRepo = await _repo.GetUser (id);
      _mapper.Map (userForUpdateDto, userRepo);

      if (await _repo.SaveAll ())
        return NoContent ();
      throw new System.Exception ($"Updating user {id} failed on save");    
  }
}
}