import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { CloudinaryModule } from '@cloudinary/ng';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { TestPabloComponent } from './test-pablo/test-pablo.component';
import { AppRoutingModule } from './app-routing.module';
import { UsuarioComponent } from './usuario/usuario.component';
import { ViviendaDetailsComponent } from './vivienda-details/vivienda-details.component';
import { ReservaDetailsComponent } from './reserva-details/reserva-details.component';

@NgModule({
  declarations: [
    AppComponent,
    TestPabloComponent,
    UsuarioComponent,
    ViviendaDetailsComponent,
    ReservaDetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    CloudinaryModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
