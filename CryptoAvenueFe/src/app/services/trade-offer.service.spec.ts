import { TestBed } from '@angular/core/testing';

import { TradeOfferService } from './trade-offer.service';

describe('TradeOfferService', () => {
  let service: TradeOfferService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TradeOfferService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
