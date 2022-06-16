import {CoinInterface} from "./coin-interface";
import {UserInterface} from "./user-interface";

export interface WalletInterface {
  id: string;
  coinID: string;
  coin: CoinInterface;
  userID: string;
  walletOwner: UserInterface;
  coinAmount: number;
}
