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
                SentAmount = newTradeOffer.SentAmount
            };

            var tradeOffer = _mapper.Map<TradeOfferPutPostDto, TradeOffer>(newTradeOffer);
            var createdTradeOffer = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetTradeOfferById), new { id = tradeOffer.Id} ,createdTradeOffer);
        }

        [HttpGet]
        [Route("get-trade-offer-by-id/{id}")]
        public async Task<IActionResult> GetTradeOfferById(Guid id)
        {
            var query = new GetTradeOfferByID { TradeOfferId = id };
            var tradeOffer = await _mediator.Send(query);

            if(tradeOffer == null)
                return NotFound();

            var foundTradeOffer = _mapper.Map<TradeOfferGetDto>(tradeOffer);
            return Ok(foundTradeOffer);
        }

        [HttpGet]
        [Route("get-trade-offer-details/{id}")]
        public async Task<IActionResult> GetTradeOfferDetails(Guid id)
        {
            var query = new GetTradeOfferDetails { TradeOfferId = id };

            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("get-trade-offer-details2/{sentCoinId}/{receivedCoinId}/{sentAmount}")]
        public async Task<IActionResult> GetTradeOfferDetails2(Guid sentCoinId, Guid receivedCoinId, double sentAmount)
        {
            var query = new GetTradeOfferDetails2 
            {
                SentCoinId = sentCoinId,
                ReceivedCoinId = receivedCoinId,
                SentAmount = sentAmount
            };

            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("get-trade-offers-by-sender-id/{senderId}")]
        public async Task<IActionResult> GetTradeOfferBySenderId(Guid senderId)
        {
            var query = new GetTradeOffersBySenderID { SenderId = senderId };
            var tradeOffers = await _mediator.Send(query);

            if (tradeOffers == null)
                return NotFound();

            var foundTradeOffers = _mapper.Map<List<TradeOfferGetDto>>(tradeOffers);
            return Ok(foundTradeOffers);
        }

        [HttpGet]
        [Route("get-trade-offers-by-recipient-id/{recipientId}")]
        public async Task<IActionResult> GetTradeOfferByRecipientId(Guid recipientId)
        {
            var query = new GetTradeOffersByRecipientID { RecipientId = recipientId };
            var tradeOffers = await _mediator.Send(query);

            if (tradeOffers == null)
                return NotFound();

            var foundTradeOffers = _mapper.Map<List<TradeOfferGetDto>>(tradeOffers);
            return Ok(foundTradeOffers);
        }

        [HttpGet]
        [Route("get-trade-offers-by-sent-coin-id/{recipientId}")]
        public async Task<IActionResult> GetTradeOfferBySentCoinId(Guid sentCoinId)
        {
            var query = new GetTradeOffersBySentCoinID { SentCoinId = sentCoinId };
            var tradeOffers = await _mediator.Send(query);

            if (tradeOffers == null)
                return NotFound();

            var foundTradeOffers = _mapper.Map<List<TradeOfferGetDto>>(tradeOffers);
            return Ok(foundTradeOffers);
        }

        [HttpGet]
        [Route("get-trade-offers-by-received-coin-id/{receivedCoinId}")]
        public async Task<IActionResult> GetTradeOfferByReceivedCoinId(Guid receivedCoinId)
        {
            var query = new GetTradeOffersByReceivedCoinID { ReceivedCoinId = receivedCoinId };
            var tradeOffers = await _mediator.Send(query);

            if (tradeOffers == null)
                return NotFound();

            var foundTradeOffers = _mapper.Map<List<TradeOfferGetDto>>(tradeOffers);
            return Ok(foundTradeOffers);
        }

        [HttpPatch]
        [HttpDelete]
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
