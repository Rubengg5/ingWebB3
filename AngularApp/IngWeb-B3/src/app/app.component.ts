import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Vivienda } from './models/vivienda';
import { ReservaService } from './services/reserva.service';
import { ViviendaService } from './services/vivienda.service';
import { NgModule } from '@angular/core';
import { Routes, RouterModule, Router } from '@angular/router'; // CLI imports router
import { TestPabloComponent } from './test-pablo/test-pablo.component';
import { SocialAuthService } from 'angularx-social-login';
import { AuthGuardService } from './services/auth-guard.service';

const routes: Routes = [
  { path: '/test-pablo', component: TestPabloComponent },
];
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'IngWeb-B3';

  constructor(viviendaService: ViviendaService, reservaService: ReservaService,
    private authGuardService: AuthGuardService) { 
    
  }

  ngOnInit() {
    
  }

}
