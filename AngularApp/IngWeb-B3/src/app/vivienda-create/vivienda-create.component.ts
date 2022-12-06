import { Component, OnInit } from '@angular/core';
import { Vivienda } from '../models/vivienda';
import { Ubicacion } from '../models/ubicacion';
import { ViviendaService } from '../services/vivienda.service';
import {v4 as uuidv4} from 'uuid';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { MapaComponent } from '../mapa/mapa.component';
import { GeocodingService } from '../services/geocoding.service';

@Component({
  selector: 'app-vivienda-create',
  templateUrl: './vivienda-create.component.html',
  styleUrls: ['./vivienda-create.component.css']
})
export class ViviendaCreateComponent implements OnInit {

  ubicacion: Ubicacion = {
    lat: 0,
    lon: 0
  }
  lat : number = 40.4165000;
  lon : number = -3.7025600;
  calle : string ;
  prueba : any;

  newVivienda: Vivienda = {
    id: "",
    nombre: "",
    descripcion: "",
    imagen: "",
    propietario: "F7761906-868C-44B7-B8A0-ECC90FCAAE47",
    localidad: "",
    provincia: "",
    ubicacion: this.ubicacion,
    tipo: "",
    calle: "",
    viviendaCompleta: true
  }

  responseOK: boolean = false;

  constructor(private geocodingService: GeocodingService, private viviendasService: ViviendaService, private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
  }

  createVivienda(){
    this.newVivienda.id = uuidv4();
    this.viviendasService.createVivivenda(this.newVivienda).subscribe(data => 
    {
        this.responseOK = data !== null;
    });

    if(this.responseOK){
      this.router.navigate(['/vivienda', this.newVivienda.id])
    }
  }
  actualizarMapa(){
    console.log("Actualizar mapa", this.calle)
    this.geocodingService.getCoordenadasFromCalle(this.calle).subscribe(data => 
    {
      this.lat= data.lat;
      this.lon= data.lon;
      this.newVivienda.ubicacion = data
    })
    }
  }
