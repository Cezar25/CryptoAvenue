import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserTradeOffersComponent } from './user-trade-offers.component';

describe('UserTradeOffersComponent', () => {
  let component: UserTradeOffersComponent;
  let fixture: ComponentFixture<UserTradeOffersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserTradeOffersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserTradeOffersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
