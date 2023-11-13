import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManaComponent } from './mana.component';

describe('ManaComponent', () => {
  let component: ManaComponent;
  let fixture: ComponentFixture<ManaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
