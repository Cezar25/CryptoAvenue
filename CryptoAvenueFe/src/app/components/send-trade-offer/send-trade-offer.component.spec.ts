import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SendTradeOfferComponent } from './send-trade-offer.component';

describe('SendTradeOfferComponent', () => {
  let component: SendTradeOfferComponent;
  let fixture: ComponentFixture<SendTradeOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SendTradeOfferComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SendTradeOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
