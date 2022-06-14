import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppTradeComponent } from './app-trade.component';

describe('AppTradeComponent', () => {
  let component: AppTradeComponent;
  let fixture: ComponentFixture<AppTradeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppTradeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppTradeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
