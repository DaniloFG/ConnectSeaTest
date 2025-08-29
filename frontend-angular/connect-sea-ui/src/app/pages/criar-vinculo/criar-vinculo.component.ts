import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Urls } from '../../Service/Urls';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-criar-vinculo.component',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './criar-vinculo.component.html'
})
export class CriarVinculoComponent implements OnInit {
  form!: FormGroup;

  dataVinculacao = new Date();
  manifestos: any[] = [];
  escalas: any[] = [];

  loadingManifestos = true;
  loadingEscalas = true;

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      manifestoId: ['', Validators.required],
      escalaId: ['', Validators.required],
      dataVinculacao: [new Date().toISOString().split('T')[0], Validators.required]
    });

    this.loadManifestos();
    this.loadEscalas();
  }

  loadManifestos() {
    this.http.get<any[]>(Urls.getManifesto).subscribe({
      next: (data) => {
        this.manifestos = data;
        this.loadingManifestos = false;
      },
      error: () => this.loadingManifestos = false
    });
  }

  loadEscalas() {
    this.http.get<any[]>(Urls.getEscala).subscribe({
      next: (data) => {
        this.escalas = data;
        this.loadingEscalas = false;
      },
      error: () => this.loadingEscalas = false
    });
  }

  onSubmit() {
    if (this.form.valid) {
      const payload = this.form.value;
      this.http.post(Urls.postManifestoEscala, payload).subscribe({
        next: (resp) => {
          Swal.fire({
            icon: 'success',
            title: 'Cadastro realizado!',
            text: 'Sucesso ao cadastrar',
            showConfirmButton: false,
            timer: 2000
          });
        },
        error: (err) => {
          let errorMessage = 'Erro inesperado ao cadastrar.';

          if (err?.error) {
            if (typeof err.error === 'string') {
              // caso backend retorne ex.Message como string
              errorMessage = err.error;
            } else if (err.error.message) {
              // caso backend retorne { message: "..." }
              errorMessage = err.error.message;
            } else if (err.error.title) {
              // caso backend retorne { title: "..." }
              errorMessage = err.error.title;
            }
          }

          Swal.fire({
            icon: 'error',
            title: 'Erro!',
            text: errorMessage,
            showConfirmButton: true
          });
        }
      });
    }
  }
}
