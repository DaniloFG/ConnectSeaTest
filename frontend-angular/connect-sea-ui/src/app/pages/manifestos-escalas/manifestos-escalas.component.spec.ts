import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManifestosEscalasComponent } from './manifestos-escalas.component';

describe('ManifestosEscalasComponent', () => {
  let component: ManifestosEscalasComponent;
  let fixture: ComponentFixture<ManifestosEscalasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManifestosEscalasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManifestosEscalasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
