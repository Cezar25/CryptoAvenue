import {UserInterface} from "./user-interface";
import {CoinInterface} from "./coin-interface";

export interface TradeOfferIncluded {
  id: string;
  senderID: string;
  sender: UserInterface;
  recipientID: string;
  recipient: UserInterface;
  sentCoinID: string;
  sentCoin: CoinInterface;
  receivedCoinID: string;
  receivedCoin: CoinInterface;
  sentAmount: number;
  receivedAmount: number;
}
