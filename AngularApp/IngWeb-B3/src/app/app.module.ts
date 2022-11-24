import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { CloudinaryModule } from '@cloudinary/ng';
import { AppComponent } from './app.component';
import { TestPabloComponent } from './test-pablo/test-pablo.component';
import { AppRoutingModule } from './app-routing.module';
import { UsuarioComponent } from './usuario/usuario.component';
import { ViviendaDetailsComponent } from './vivienda-details/vivienda-details.component';
import { ReservaDetailsComponent } from './reserva-details/reserva-details.component';
import { LoginComponent } from './login/login.component';
import { GoogleLoginProvider, SocialLoginModule } from 'angularx-social-login';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {MatCardModule} from '@angular/material/card';
import { ViviendasComponent } from './viviendas/viviendas.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';


@NgModule({
  declarations: [
    AppComponent,
    TestPabloComponent,
    UsuarioComponent,
    ViviendaDetailsComponent,
    ReservaDetailsComponent,
    LoginComponent,
    ViviendasComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    CloudinaryModule,
    SocialLoginModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule
  ],
  providers: [{
    provide: 'SocialAuthServiceConfig',
    useValue: {
      autoLogin: true, //keeps the user signed in
      providers: [
        {
          id: GoogleLoginProvider.PROVIDER_ID,
          provider: new GoogleLoginProvider('182737891985-bhlpao31dj89qgu93i4pp3die544nomb.apps.googleusercontent.com') // your client id
        }
      ]
    }
  },
  //AuthGuardService
],
  bootstrap: [AppComponent]
})
export class AppModule { }
