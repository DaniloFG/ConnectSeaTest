import { Routes } from '@angular/router';
import { MainLayoutComponent } from './pages/main-layout/main-layout.component';
import { LoginComponent } from './pages/login/login.component';
import { ManifestoComponent } from './pages/manifesto/manifesto.component';
import { EscalaComponent } from './pages/escala/escala.component';
import { ManifestosEscalasComponent } from './pages/manifestos-escalas/manifestos-escalas.component';
import { CriarVinculoComponent } from './pages/criar-vinculo/criar-vinculo.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';

export const routes: Routes = [
    {path: '', redirectTo: 'login', pathMatch: 'full' },
    {path: 'login', component: LoginComponent},
    {
        path: 'app', component: MainLayoutComponent,
        children: [
            {path: 'manifestos', component: ManifestoComponent},
            {path: 'escalas', component: EscalaComponent},
            {path: 'vinculos', component: ManifestosEscalasComponent},
            {path: 'criarvinculo', component: CriarVinculoComponent},
            {path: 'dashboard', component: DashboardComponent},
        ]
    },
];
