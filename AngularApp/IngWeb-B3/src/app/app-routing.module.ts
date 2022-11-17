import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ReservaDetailsComponent } from './reserva-details/reserva-details.component';
import { TestPabloComponent } from './test-pablo/test-pablo.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { ViviendaDetailsComponent } from './vivienda-details/vivienda-details.component';

const routes: Routes = [
  { path: 'inicio', component: AppComponent },
  { path: 'pablo', component: TestPabloComponent },
  { path: 'usuario/:id', component: UsuarioComponent },
  { path: 'reserva/:id', component: ReservaDetailsComponent }
  { path: 'vivienda/:id', component: ViviendaDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
