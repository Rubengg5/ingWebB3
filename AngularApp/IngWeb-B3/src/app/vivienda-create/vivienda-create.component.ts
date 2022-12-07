import { Component, OnInit } from '@angular/core';
import { Vivienda } from '../models/vivienda';
import { Ubicacion } from '../models/ubicacion';
import { ViviendaService } from '../services/vivienda.service';
import {v4 as uuidv4} from 'uuid';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { MapaComponent } from '../mapa/mapa.component';
import { GeocodingService } from '../services/geocoding.service';
import axios from "axios";
import { strict } from 'assert';
import { environment } from '../../environments/environment';

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
  datos : unknown = "-1";

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
    //Si se ha cargado una imagen desde el pc del cliente entonces la subimos a Cloudinary y se guarda en newVivienda su nueva ruta relativa
    if(this.datos !== "-1"){
      //this.mandarAPI(this.datos)
    }
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

    async capturarFile($event: Event) {
      const target = $event.target as HTMLInputElement
      if (target.files !== null){
        let file = (target.files[0]);
        this.datos = await this.encodeImageFileAsURL(file)
        this.mandarAPI(this.datos)
      }
      }

    encodeImageFileAsURL(element: File | null) {
      return new Promise(resolve=>{
      if (element !== null) {
        var file = element
        var reader = new FileReader();
        reader.onloadend = function() {
          resolve(reader.result)
      }
      reader.readAsDataURL(file);
      }
    })
    }

    mandarAPI(data: unknown){
        var nombreArchivo=""
        const payload = { "file" : data , "api_key": "714814147251835", "upload_preset": "ontg4fqa" };
        console.log(payload)
        axios.post(environment.cloudinaryApiUrl, payload).then((response) => {
          console.log(response.data);
          nombreArchivo = response.data["public_id"]
          this.newVivienda.imagen=nombreArchivo
      }).catch((error) => {
          console.error(error);
      });
      }
  }
