export interface TradeOfferInterface {
  id: string;
  senderID: string;
  recipientID: string;
  sentCoinID: string;
  receivedCoinID: string;
  sentAmount: number;
  receivedAmount: number;
}
