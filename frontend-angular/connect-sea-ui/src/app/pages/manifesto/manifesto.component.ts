import { Component, OnInit } from '@angular/core';
import { Manifesto } from '../../models/manifesto-models';
import { HttpClient } from '@angular/common/http';
import { Urls } from '../../Service/Urls';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-manifesto.component',
  imports: [CommonModule],
  templateUrl: './manifesto.component.html',
  styleUrls: ['./manifesto.component.scss']
})
export class ManifestoComponent implements OnInit {
  manifestoList: Manifesto[] = [];
  loading = true;
  error: string | null = null;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.loadEscalas();
  }

  loadEscalas() {
    this.loading = true;
    this.error = null;
    this.http.get<Manifesto[]>(Urls.getManifesto)
      .subscribe({
        next: (data) => {
          this.manifestoList = data;
          this.loading = false;
        },
        error: (err) => {
          this.error = 'Erro ao carregar os dados.';
          this.loading = false;
        }
      });
  }
}