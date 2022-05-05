using AutoMapper;
using CryptoAvenue.Application.Commands;
using CryptoAvenue.Application.Commands.UserWalletCommands;
using CryptoAvenue.Application.Queries;
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

            var createdWallet = await _mediator.Send(command);

            var wallet = _mapper.Map<WalletPutPostDto, Wallet>(newWallet);

            

            return CreatedAtAction(nameof(GetWalletById), new { id = wallet.Id }, createdWallet);
        }

        [HttpGet]
        [Route("get-wallet-by-id/{id}")]
        public async Task<IActionResult> GetWalletById(Guid id)
        {
            var query = new GetWalletByID { WalletId = id };
            var wallet = await _mediator.Send(query);

            if (wallet == null)
                return NotFound();

            var foundWallet = _mapper.Map<WalletGetDto>(wallet);
            return Ok(foundWallet);
        }

        [HttpGet]
        [Route("get-wallets-by-coin-id/{id}")]
        public async Task<IActionResult> GetWalletsByCoinId(Guid id)
        {
            var query = new GetWalletsByCoinID { CoinId = id };
            var wallets = await _mediator.Send(query);

            if (wallets == null)
                return NotFound();

            var foundWallets = _mapper.Map<List<WalletGetDto>>(wallets);
            return Ok(foundWallets);
        }

        [HttpGet]
        [Route("get-wallets-by-user-id/{id}")]
        public async Task<IActionResult> GetWalletsByUserId(Guid id)
        {
            var query = new GetWalletsByUserID { UserId = id };
            var wallets = await _mediator.Send(query);

            if (wallets == null)
                return NotFound();

            var foundWallets = _mapper.Map<List<WalletGetDto>>(wallets);
            return Ok(foundWallets);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWallets()
        {
            var wallets = await _mediator.Send(new GetAllWallets());

            var foundWallets = _mapper.Map<List<WalletGetDto>>(wallets);
            return Ok(foundWallets);
        }

        [HttpPatch]
        [Route("update-wallet/{id}")]
        public async Task<IActionResult> UpdateWallet(Guid id, WalletPutPostDto updatedWallet)
        {
            var command = new UpdateWallet
            {
                WalletId = id,
                CoinID = updatedWallet.CoinID,
                UserID = updatedWallet.UserID,
                CoinAmount = updatedWallet.CoinAmount
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}/{amount}")]
        public async Task<IActionResult> UpdateWalletCoinAmount(Guid id, WalletPutPostDto updatedWallet, double amount)
        {
            var command = new UpdateWallet
            {
                WalletId=id,
                CoinID = updatedWallet.CoinID,
                UserID = updatedWallet.UserID,
                CoinAmount = amount
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("add-amount-to-wallet/{id}/{amount}")]
        public async Task<IActionResult> AddAmountToWallet(Guid id, double amount)
        {
            var command = new AddToWalletCoinAmount
            {
                WalletId = id,
                AddedAmount = amount
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("deduct-amount-from-wallet/{id}/{amount}")]
        public async Task<IActionResult> DeductAmountToWallet(Guid id, double amount)
        {
            var command = new DeductFromWalletCoinAmount
            {
                WalletId = id,
                DeductedAmount = amount
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("convert-coins-in-user-wallet/{userId}/{walletId}/{boughtCoinId}/{soldCoinAmount}")]
        public async Task<IActionResult> ConvertCoinsInUserWallet(Guid userId, Guid walletId, Guid boughtCoinId, double soldCoinAmount)
        {
            var command = new ConvertCoinsFromUserWallets
            {
                UserId = userId,
                WalletId = walletId,
                BoughtCoinID = boughtCoinId,
                AmountOfSoldCoin = soldCoinAmount
            };

            var result = await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteWallet(Guid id)
        {
            var command = new DeleteWallet { WalletId = id };
            var foundWallet = await _mediator.Send(command);

            if (foundWallet == null) return NotFound();

            return NoContent();
        }

        //[HttpPut]
        //[Route("deposit-money/{userId}/{coinId}/{depositedAmount}")]
        //public async Task<IActionResult> DepositToWallet(Guid userId, Guid coinId, double depositedAmount)
        //{
        //    var command = new DepositToUserAccount
        //    {
        //        UserId = userId,
        //        CoinId = coinId,
        //        Amount = depositedAmount
        //    };

        //    await _mediator.Send(command);
        //    return NoContent();
        //}

        //[HttpPatch]
        //[Route("withdraw-money/{userId}/{coinId}/{withdrawnAmount}")]
        //public async Task<IActionResult> WithdrawFromWallet(Guid userId, Guid coinId, double withdrawnAmount)
        //{
        //    var command = new WithdrawFromUserAccount
        //    {
        //        UserId = userId,
        //        CoinId = coinId,
        //        Amount = withdrawnAmount
        //    };

        //    await _mediator.Send(command);
        //    return NoContent();
        //}
    }
}
