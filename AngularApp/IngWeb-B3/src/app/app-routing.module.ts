import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { TestPabloComponent } from './test-pablo/test-pablo.component';
import { UsuarioComponent } from './usuario/usuario.component';

const routes: Routes = [
  { path: 'inicio', component: AppComponent },
  { path: 'pablo', component: TestPabloComponent },
  { path: 'usuario/:id', component: UsuarioComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
