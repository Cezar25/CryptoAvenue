using AutoMapper;
using CryptoAvenue.Application.Commands.CoinCommands;
using CryptoAvenue.Application.Queries;
using CryptoAvenue.Application.Queries.CoinQueries;
using CryptoAvenue.Domain.Models;
using CryptoAvenue.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAvenue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public CoinsController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoin(CoinPutPostDto newCoin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateCoin
            {
                Name = newCoin.Name,
                Abreviation = newCoin.Abreviation,
                ValueInEUR = newCoin.ValueInEUR,
                ValueInUSD = newCoin.ValueInUSD,
                ValueInBTC = newCoin.ValueInBTC
            };

            var coin = _mapper.Map<CoinPutPostDto, Coin>(newCoin);

            var createdCoin = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = coin.Id }, coin);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoins()
        {
            var coins = await _mediator.Send(new GetAllCoins());

            var foundCoins = _mapper.Map<List<CoinGetDto>>(coins);
            return Ok(foundCoins);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCoinByID { CoinId = id };
            var coin = await _mediator.Send(query);

            if (coin == null)
                return NotFound();

            var foundCoin = _mapper.Map<CoinGetDto>(coin);
            return Ok(foundCoin);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCoin(Guid id,[FromBody] CoinPutPostDto updatedCoin)
        {
            var command = new UpdateCoin
            {
                Name = updatedCoin.Name,
                Abreviation = updatedCoin.Abreviation,
                ValueInEUR = updatedCoin.ValueInEUR,
                ValueInUSD = updatedCoin.ValueInUSD,
                ValueInBTC = updatedCoin.ValueInBTC
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteCoin(Guid id)
        {
            var command = new DeleteCoin { CoinId = id };
            var foundCoin = await _mediator.Send(command);

            if (foundCoin == null) return NotFound();

            return NoContent();
        }

    }
}
