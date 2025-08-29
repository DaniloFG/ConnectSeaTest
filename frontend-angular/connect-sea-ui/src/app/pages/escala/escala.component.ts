import { Component, OnInit } from '@angular/core';
import { Urls } from '../../Service/Urls';
import { HttpClient } from '@angular/common/http';
import { Escala } from '../../models/escala-models';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-escala.component',
  imports: [CommonModule],
  templateUrl: './escala.component.html',
  styleUrls: ['./escala.component.scss']
})
export class EscalaComponent implements OnInit {
  escalaList: Escala[] = [];
  loading = true;
  error: string | null = null;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.loadEscalas();
  }

  loadEscalas() {
    this.loading = true;
    this.error = null;
    this.http.get<Escala[]>(Urls.getEscala)
      .subscribe({
        next: (data) => {
          this.escalaList = data;
          this.loading = false;
        },
        error: (err) => {
          this.error = 'Erro ao carregar os dados.';
          this.loading = false;
        }
      });
  }
}
