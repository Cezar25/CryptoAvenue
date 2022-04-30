using AutoMapper;
using CryptoAvenue.Application.Commands;
using CryptoAvenue.Application.Commands.UserCommands;
using CryptoAvenue.Application.Queries;
using CryptoAvenue.Application.Queries.UserQueries;
using CryptoAvenue.Domain.Models;
using CryptoAvenue.Dtos.UserDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAvenue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public UsersController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserPutPostDto newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateUser
            {
                Email = newUser.Email,
                Password = newUser.Password,
                Age = newUser.Age,
                SecurityQuestion = newUser.SecurityQuestion,
                SecurityAnswer = newUser.SecurityAnswer,
                PrivateProfile = newUser.PrivateProfile
            };

            var user = _mapper.Map<UserPutPostDto, User>(newUser);
            var createdUser = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, createdUser);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var query = new GetUserByID { UserId = id };
            var user = await _mediator.Send(query);

            if(user == null) 
                return NotFound();

            var foundUser = _mapper.Map<UserGetDto>(user);
            return Ok(foundUser);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsers());
            
            var foundUsers = _mapper.Map<List<UserGetDto>>(users);
            return Ok(foundUsers);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserPutPostDto updatedUser)
        {
            var command = new UpdateUser
            {
                UserId = id,
                Email = updatedUser.Email,
                Password = updatedUser.Password,
                SecurityQuestion = updatedUser.SecurityQuestion,
                SecurityAnswer = updatedUser.SecurityAnswer,
                PrivateProfile = updatedUser.PrivateProfile
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPut]
        [Route("{id}/{email}")]
        public async Task<IActionResult> UpdateUserEmail(Guid id, UserPutPostDto updatedUser, string email)
        {
            var command = new UpdateUser
            {
                Email = email,
                Password = updatedUser.Password,
                SecurityQuestion = updatedUser.SecurityQuestion,
                SecurityAnswer = updatedUser.SecurityAnswer,
                PrivateProfile = updatedUser.PrivateProfile
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }
        //[HttpPut]
        //[Route("{id}/{password}")]
        //public async Task<IActionResult> UpdateUserPassword(Guid id, UserPutPostDto updatedUser, string password)
        //{
        //    var command = new UpdateUser
        //    {
        //        Email = updatedUser.Email,
        //        Password = password,
        //        SecurityQuestion = updatedUser.SecurityQuestion,
        //        SecurityAnswer = updatedUser.SecurityAnswer,
        //        PrivateProfile = updatedUser.PrivateProfile
        //    };

        //    var result = await _mediator.Send(command);

        //    if (result == null)
        //        return NotFound();

        //    return NoContent();
        //}

        //[HttpPut]
        //[Route("{id}/{question}/{answer}")]
        //public async Task<IActionResult> UpdateUserQnA(Guid id, UserPutPostDto updatedUser, string question, string answer)
        //{
        //    var command = new UpdateUser
        //    {
        //        Email = updatedUser.Email,
        //        Password = updatedUser.Password,
        //        SecurityQuestion = question,
        //        SecurityAnswer = answer,
        //        PrivateProfile = updatedUser.PrivateProfile
        //    };

        //    var result = await _mediator.Send(command);

        //    if (result == null)
        //        return NotFound();

        //    return NoContent();
        //}

        //[HttpPut]
        //[Route("{id}/{profileType}")]
        //public async Task<IActionResult> UpdateUserProfileType(Guid id, UserPutPostDto updatedUser, bool profileType)
        //{
        //    var command = new UpdateUser
        //    {
        //        Email = updatedUser.Email,
        //        Password = updatedUser.Password,
        //        SecurityQuestion = updatedUser.SecurityQuestion,
        //        SecurityAnswer = updatedUser.SecurityAnswer,
        //        PrivateProfile = profileType
        //    };

        //    var result = await _mediator.Send(command);

        //    if (result == null)
        //        return NotFound();

        //    return NoContent();
        //}

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUser { UserId = id };
            var foundCoin = await _mediator.Send(command);

            if (foundCoin == null) return NotFound();

            return NoContent();
        }

        //[HttpGet]
        //[Route("{email}")]
        //public async Task<IActionResult> GetUserByEmail(string email)
        //{
        //    var query = new GetUserByEmail { UserEmail = email };
        //    var user = await _mediator.Send(query);

        //    if (user == null)
        //        return NotFound();

        //    var foundUser = _mapper.Map<UserGetDto>(user);
        //    return Ok(foundUser);
        //}

    }
}
