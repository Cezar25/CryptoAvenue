using AutoMapper;
using CryptoAvenue.Application.Commands;
using CryptoAvenue.Application.Commands.TradeOfferCommands;
using CryptoAvenue.Application.Queries;
using CryptoAvenue.Application.Queries.TradeOfferQueries;
using CryptoAvenue.Domain.Models;
using CryptoAvenue.Dtos.TradeOfferDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAvenue.Controllers
{
    [Route("CryptoAvenue/[controller]")]
    [ApiController]
    public class TradeOffersController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public TradeOffersController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Does smth
        /// </summary>
        /// <param name="newTradeOffer"></param>
        /// <returns>return smth</returns>
        [HttpPost]
        public async Task<IActionResult> CreateTradeOffer(TradeOfferPutPostDto newTradeOffer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateTradeOffer
            {
                SenderId = newTradeOffer.SenderID,
                RecipientId = newTradeOffer.RecipientID,
                SentCoinId = newTradeOffer.SentCoinID,
                ReceivedCoinId = newTradeOffer.ReceivedCoinID,
                SentAmount = newTradeOffer.SentAmount,
                ReceivedAmount = newTradeOffer.ReceivedAmount
            };

            var tradeOffer = _mapper.Map<TradeOfferPutPostDto, TradeOffer>(newTradeOffer);
            var createdTradeOffer = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetTradeOfferById), new { id = tradeOffer.Id} ,createdTradeOffer);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTradeOfferById(Guid id)
        {
            var query = new GetTradeOfferByID { TradeOfferId = id };
            var tradeOffer = await _mediator.Send(query);

            if(tradeOffer == null)
                return NotFound();

            var foundTradeOffer = _mapper.Map<TradeOfferGetDto>(tradeOffer);
            return Ok(foundTradeOffer);
        }

        [HttpPut]
        [Route("apply-trade-offer-to-users/{id}")]
        public async Task<IActionResult> AcceptTradeOffer(Guid id)
        {
            var command = new ApplyTradeOfferToUsers
            {
                TradeOfferId = id
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTradeOffers()
        {
            var tradeOffers = await _mediator.Send(new GetAllTradeOffers());

            var foundOffers = _mapper.Map<List<TradeOfferGetDto>>(tradeOffers);
            return Ok(foundOffers);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTradeOffer(Guid id)
        {
            var command = new DeleteTradeOffer { TradeOfferId= id };
            var foundTradeOffer = await _mediator.Send(command);

            if (foundTradeOffer == null)
                return NotFound();

            return NoContent();
        }
    }
}
