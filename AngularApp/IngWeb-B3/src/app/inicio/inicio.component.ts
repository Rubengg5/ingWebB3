import { Component, NgZone, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CredentialResponse } from 'google-one-tap';
import { environment } from '../../environments/environment';
import { Vivienda } from '../models/vivienda';
import { AuthGuardService } from '../services/auth-guard.service';
import { ReservaService } from '../services/reserva.service';
import { ViviendaService } from '../services/vivienda.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {

  viviendaList: Vivienda[] = [];
  private clientId = environment.clientId

  constructor(private viviendaService: ViviendaService, reservaService: ReservaService,
    private router: Router,
    private service: AuthGuardService,
    private _ngZone: NgZone) { }

  ngOnInit(): void {
    this.viviendaService.getViviendas()
    .subscribe(data => 
      {
        this.viviendaList = data;
        console.log(this.viviendaList);
      });
  }

}
