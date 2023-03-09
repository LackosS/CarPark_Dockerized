import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservationsTableComponent } from './reservations-table.component';

describe('ReservationsTableComponent', () => {
  let component: ReservationsTableComponent;
  let fixture: ComponentFixture<ReservationsTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReservationsTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReservationsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
