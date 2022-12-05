import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GasolinerasService } from '../services/gasolineras.service';

@Component({
  selector: 'app-gasolineras',
  templateUrl: './gasolineras.component.html',
  styleUrls: ['../../styles.css']
})
export class GasolinerasComponent implements OnInit {
  feature: any = null;
  latitudGasolinera: number = 0;
  longitudGasolinera: number = 0;

  constructor(private route: ActivatedRoute,
    private gasolinerasService: GasolinerasService) { }

  ngOnInit(): void {
    this.getGasolinerasByLocalidad("Nerja");
    this.getGasolinerasByProvincia("Málaga");
  }

  getGasolinerasByLocalidad(localidad: string){
    this.gasolinerasService.getGasolinerasByLocalidad(localidad)
    .subscribe(data => 
      {
        this.feature = data;
        this.latitudGasolinera = this.feature.attributes.latitud;
        this.longitudGasolinera = this.feature.attributes.longitud;
        console.log(this.latitudGasolinera);
        console.log(this.longitudGasolinera);
      });
  }

  getGasolinerasByProvincia(provincia: string){
    this.gasolinerasService.getGasolinerasByProvincia(provincia)
    .subscribe(data => 
      {
        // this.gasolinera = Convert.toGasolinera(data);
        // console.log(this.gasolinera);
        // this.latitudGasolinera = this.gasolinera.attributes.Latitud;
        // this.longitudGasolinera = this.gasolinera.attributes.Longitud;
      });
  }

}
