import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BankTransferInfoComponent } from './bank-transfer-info.component';

describe('BankTransferInfoComponent', () => {
  let component: BankTransferInfoComponent;
  let fixture: ComponentFixture<BankTransferInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BankTransferInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BankTransferInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
