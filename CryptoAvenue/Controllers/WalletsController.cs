using AutoMapper;
using CryptoAvenue.Application.Commands;
using CryptoAvenue.Application.Commands.UserWalletCommands;
using CryptoAvenue.Application.Queries.WalletQueries;
using CryptoAvenue.Domain.Models;
using CryptoAvenue.Dtos.WalletDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAvenue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public WalletsController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWallet(WalletPutPostDto newWallet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateWallet
            {
                CoinId = newWallet.CoinID,
                UserId = newWallet.UserID,
                CoinAmount = newWallet.CoinAmount,
            };

            var wallet = _mapper.Map<WalletPutPostDto, Wallet>(newWallet);
            var createdWallet = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetWalletById), new { id = wallet.Id }, createdWallet);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetWalletById(Guid id)
        {
            var query = new GetWalletByID { WalletId = id };
            var wallet = await _mediator.Send(query);

            if (wallet == null)
                return NotFound();

            var foundWallet = _mapper.Map<WalletGetDto>(wallet);
            return Ok(foundWallet);
        }

        [HttpPut]
        [Route("{id}/{amount}")]
        public async Task<IActionResult> UpdateWalletCoinAmount(Guid id, WalletPutPostDto updatedWallet, double amount)
        {
            var command = new UpdateWallet
            {
                CoinID = updatedWallet.CoinID,
                UserID = updatedWallet.UserID,
                CoinAmount = amount
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteWallet(Guid id)
        {
            var command = new DeleteWallet { WalletId = id };
            var foundWallet = await _mediator.Send(command);

            if (foundWallet == null) return NotFound();

            return NoContent();
        }
    }
}
