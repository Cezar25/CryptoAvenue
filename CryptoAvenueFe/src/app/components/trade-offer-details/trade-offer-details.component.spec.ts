import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TradeOfferDetailsComponent } from './trade-offer-details.component';

describe('TradeOfferDetailsComponent', () => {
  let component: TradeOfferDetailsComponent;
  let fixture: ComponentFixture<TradeOfferDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TradeOfferDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TradeOfferDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
