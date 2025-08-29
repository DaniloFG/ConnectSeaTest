import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { HttpClient } from '@angular/common/http';
import { Urls } from '../../Service/Urls';

@Component({
  selector: 'app-dashboard.component',
  imports: [CommonModule, NgxChartsModule],
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {
  manifestos: any[] = [];
  escalas: any[] = [];
  manifestosEscalas: any[] = [];

  // dados para gráficos
  graficoManifestos: any[] = [];
  graficoEscalas: any[] = [];
  graficoRelacionamento: any[] = [];

  view: [number, number] = [300, 200]; // tamanho base (ajusta responsivo)

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.http.get<any[]>(Urls.getManifesto).subscribe((data) => {
      this.manifestos = data;
      this.graficoManifestos = [
        { name: 'Manifestos', value: data.length }
      ];
    });

    this.http.get<any[]>(Urls.getEscala).subscribe((data) => {
      this.escalas = data;
      this.graficoEscalas = [
        { name: 'Escalas', value: data.length }
      ];
    });

    this.http.get<any[]>(Urls.getManifestoEscala).subscribe((data) => {
      this.manifestosEscalas = data;

      // agrupa por manifestoId para contar quantas escalas vinculadas
      const relacionamento = Object.values(
        data.reduce((acc: any, curr: any) => {
          acc[curr.manifestoId] = acc[curr.manifestoId] || { name: `Manifesto ${curr.manifestoId}`, value: 0 };
          acc[curr.manifestoId].value++;
          return acc;
        }, {})
      );

      this.graficoRelacionamento = relacionamento as any[];
    });
  }
}
