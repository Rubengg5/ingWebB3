import { Component, OnInit } from '@angular/core';
import { Vivienda } from '../models/vivienda';
import { Ubicacion } from '../models/ubicacion';
import { ViviendaService } from '../services/vivienda.service';
import {v4 as uuidv4} from 'uuid';

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
    viviendaCompleta: true
  }
  constructor(private viviendasService: ViviendaService) { }

  ngOnInit(): void {
  }

  createVivienda(){
    this.newVivienda.id = uuidv4();
    this.viviendasService.createVivivenda(this.newVivienda).subscribe(data => 
      {
        console.log(data)
      });
  }
}