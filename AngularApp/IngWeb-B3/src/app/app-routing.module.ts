import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { InicioComponent } from './inicio/inicio.component';
import { LoginComponent } from './login/login.component';
import { ReservaDetailsComponent } from './reserva-details/reserva-details.component';
import { ReservasComponent } from './reservas/reservas.component';
import { TestPabloComponent } from './test-pablo/test-pablo.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { ViviendaDetailsComponent } from './vivienda-details/vivienda-details.component';
import { ViviendasComponent } from './viviendas/viviendas.component';

const routes: Routes = [
  { path: '', component: InicioComponent },
  { path: 'pablo', component: TestPabloComponent },
  { path: 'usuario/:id', component: UsuarioComponent },
  { path: 'reserva/:id', component: ReservaDetailsComponent },
  { path: 'vivienda/:id', component: ViviendaDetailsComponent },
  {path: 'login', component: LoginComponent},
  {path: 'viviendas/:id', component: ViviendasComponent},
  {path: 'reservas/:id', component: ReservasComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
