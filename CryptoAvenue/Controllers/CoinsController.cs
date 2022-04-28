using AutoMapper;
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

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCoinByID { CoinId = id };
            var coin = await _mediator.Send(query);

            if(coin == null)
                return NotFound();

            var foundCoin = _mapper.Map<CoinGetDto>(coin);
            return Ok(foundCoin);
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









        //[HttpGet]
        //    public IActionResult GetCoinById()
        //    {
        //        var coin = new Coin()
        //        {
        //            Name = "Dollar",
        //            Abreviation = "USD",
        //            ValueInEUR = 0.8,
        //            ValueInUSD = 1,
        //            ValueInBTC = 2
        //        };
        //        return Ok(coin);
        //    }

        //    [HttpPost]
        //    public IActionResult CreateCoin(CoinDto newCoin)
        //    {
        //        return CreatedAtAction(nameof(GetCoinById), newCoin);
        //    }

        //    [HttpGet]
        //    [Route("{id}")]
        //    public IActionResult GetCoinById(Guid id)
        //    {
        //        var coin = new Coin()
        //        {
        //            Name = "Dollar",
        //            Abreviation = "USD",
        //            ValueInEUR = 0.8,
        //            ValueInUSD = 1,
        //            ValueInBTC = 2,
        //            Id = id
        //        };
        //        return Ok(coin);
        //    }
    }
}
