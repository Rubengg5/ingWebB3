import { Component, OnInit } from '@angular/core';
import { Vivienda } from './models/vivienda';
import { ReservaService } from './services/reserva.service';
import { ViviendaService } from './services/vivienda.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'IngWeb-B3';
  private viviendaService;
  private reservaService;
  //viviendasList: Vivienda[] = [];
  vivienda: any;

  constructor(viviendaService: ViviendaService, reservaService: ReservaService) { 
    this.viviendaService = viviendaService;
    this.reservaService = reservaService;
    this.reservaService.getReservaByFechas("2022-11-22", "2022-11-30")
    .subscribe(data => 
      {
        this.vivienda = data;
        console.log("data: "+data);
        console.log(this.vivienda);
      });


  }

  ngOnInit() {
    
  }
}
