import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { InicioComponent } from './inicio/inicio.component';
import { LoginComponent } from './login/login.component';
import { MapaComponent } from './mapa/mapa.component';
import { ReservaCreateComponent } from './reserva-create/reserva-create.component';
import { ReservaDetailsComponent } from './reserva-details/reserva-details.component';
import { ReservaModifyComponent } from './reserva-modify/reserva-modify.component';
import { ReservasViviendaComponent } from './reservas-vivienda/reservas-vivienda.component';
import { ReservasComponent } from './reservas/reservas.component';
import { TestPabloComponent } from './test-pablo/test-pablo.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { ViviendaCreateComponent } from './vivienda-create/vivienda-create.component';
import { ViviendaDetailsComponent } from './vivienda-details/vivienda-details.component';
import { ViviendaModifyComponent } from './vivienda-modify/vivienda-modify.component';
import { ViviendasComponent } from './viviendas/viviendas.component';

const routes: Routes = [
  { path: '', component: InicioComponent },
  { path: 'pablo', component: TestPabloComponent },
  { path: 'mapa', component: MapaComponent},
  { path: 'usuario/:id', component: UsuarioComponent },
  { path: 'reserva/:id', component: ReservaDetailsComponent },
  { path: 'vivienda/:id', component: ViviendaDetailsComponent },
  {path: 'login', component: LoginComponent},
  {path: 'viviendas/:id', component: ViviendasComponent},
  {path: 'reservas/:id', component: ReservasComponent},
  {path: 'newVivienda', component: ViviendaCreateComponent},
  {path: 'newReserva/:id', component: ReservaCreateComponent},
  {path: 'modifyReserva/:id', component: ReservaModifyComponent},
  {path: 'modifyVivienda/:id', component: ViviendaModifyComponent},
  {path: 'reservasVivienda/:id', component: ReservasViviendaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
