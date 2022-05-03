using AutoMapper;
using CryptoAvenue.Application.Commands;
using CryptoAvenue.Application.Commands.UserCommands;
using CryptoAvenue.Application.Commands.UserWalletCommands;
using CryptoAvenue.Application.Queries;
using CryptoAvenue.Application.Queries.UserQueries;
using CryptoAvenue.Domain.Models;
using CryptoAvenue.Dtos.UserDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Http;

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

            User createdUser = null;

            try
            {
                createdUser = await _mediator.Send(command);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return NotFound();
            }

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, createdUser);
        }

        [HttpGet]
        [Route("get-user-by-id/{id}")]
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
        [Route("get-user-by-email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var query = new GetUserByEmail { UserEmail = email };
            var user = await _mediator.Send(query);

            if (user == null)
                return NotFound();

            var foundUser = _mapper.Map<UserGetDto>(user);
            return Ok(foundUser);
        }

        [HttpGet]
        [Route("get-user-portofolio-value-eur/{id}")]
        public async Task<IActionResult> GetTotalPortofolioValueEURById(Guid id)
        {
            var command = new GetTotalUserWalletsValueEUR { UserId = id };
            var amount = await _mediator.Send(command);

            return Ok(amount);
        }

        [HttpGet]
        [Route("get-user-portofolio-value-usd/{id}")]
        public async Task<IActionResult> GetTotalPortofolioValueUSDById(Guid id)
        {
            var command = new GetTotalUserWalletsValueUSD { UserId = id };
            var amount = await _mediator.Send(command);

            return Ok(amount);
        }

        [HttpGet]
        [Route("get-user-portofolio-value-btc/{id}")]
        public async Task<IActionResult> GetTotalPortofolioValueBTCById(Guid id)
        {
            var command = new GetTotalUserWalletsValueBTC { UserId = id };
            var amount = await _mediator.Send(command);

            return Ok(amount);
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

        [HttpPatch]
        [Route("{id}/update-user-email/{newEmail}")]
        public async Task<IActionResult> UpdateUserEmail(Guid id, string newEmail)
        {
            var command = new UpdateUserEmail
            {
                UserId = id,
                UserEmail = newEmail
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}/update-user-password/{newPassword}")]
        public async Task<IActionResult> UpdateUserPassword(Guid id, string newPassword)
        {
            var command = new UpdateUserPassword
            {
                UserId = id,
                UserPassword = newPassword
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("update-user-profile-type/{id}")]
        public async Task<IActionResult> UpdateUserProfileType(Guid id)
        {
            var command = new UpdateUserProfileType
            {
                UserID = id
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}/update-user-QnA/{newQuestion}/{newAnswer}")]
        public async Task<IActionResult> UpdateUserPassword(Guid id, string newQuestion, string newAnswer)
        {
            var command = new UpdateUserQnA
            {
                UserId = id,
                UserSecurityQuestion = newQuestion,
                UserSecurityAnswer = newAnswer
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUser { UserId = id };
            var foundCoin = await _mediator.Send(command);

            if (foundCoin == null) return NotFound();

            return NoContent();
        }

    }
}
