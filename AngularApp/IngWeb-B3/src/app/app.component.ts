import { Component, OnInit } from '@angular/core';
import { Vivienda } from './models/vivienda';
import { ViviendaService } from './services/vivienda.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'IngWeb-B3';
  private viviendaService;
  viviendasList: Vivienda[] = [];

  constructor(viviendaService: ViviendaService) { 
    this.viviendaService = viviendaService;

    this.viviendaService.getViviendas()
    .subscribe((data: Vivienda[]) => this.viviendasList = data);
  }

  ngOnInit() {
    
  }
}
