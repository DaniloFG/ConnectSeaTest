import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarVinculoComponent } from './criar-vinculo.component';

describe('CriarVinculoComponent', () => {
  let component: CriarVinculoComponent;
  let fixture: ComponentFixture<CriarVinculoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CriarVinculoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CriarVinculoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
