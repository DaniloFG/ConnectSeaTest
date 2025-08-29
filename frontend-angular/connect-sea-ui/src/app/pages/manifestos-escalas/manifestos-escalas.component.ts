import { Component, OnInit } from '@angular/core';
import { ManifestoEscala } from '../../models/manifesto-escala-models';
import { HttpClient } from '@angular/common/http';
import { Urls } from '../../Service/Urls';
import { CommonModule } from '@angular/common';
import { map } from 'rxjs';

@Component({
  selector: 'app-manifestos-escalas.component',
  imports: [CommonModule],
  templateUrl: './manifestos-escalas.component.html',
  styleUrls: ['./manifestos-escalas.component.scss']
})
export class ManifestosEscalasComponent implements OnInit {
  manifestoEscalaList: ManifestoEscala[] = [];
  loading = true;
  error: string | null = null;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.loadEscalas();
  }

  loadEscalas() {
    this.loading = true;
    this.error = null;
    this.http.get<ManifestoEscala[]>(Urls.getManifestoEscala)
      .subscribe({
        next: (data) => {
          this.manifestoEscalaList = data;
          this.loading = false;
        },
        error: (err) => {
          this.error = 'Erro ao carregar os dados.';
          this.loading = false;
        }
      });
  }
}