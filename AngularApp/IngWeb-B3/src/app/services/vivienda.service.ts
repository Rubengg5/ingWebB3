import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { environment } from '../../environments/environment';
import { Vivienda } from '../models/vivienda';


@Injectable({
  providedIn: 'root'
})
export class ViviendaService {

  constructor(private http: HttpClient) { 
    
  }

  getViviendas(): Observable<Vivienda[]>{
    var viviendas = this.http.get<Vivienda[]>(environment.baseURL+"/api/Viviendas");

    return viviendas;
  }

  createVivivenda(){

  }

  getViviendaById(id: string){

  }

  updateVivienda(id: string){

  }

  deleteVivienda(id: string){

  }

  getViviendaByPropietario(id: string){

  }

  getViviendaByLocalidad(localidad: string){

  }

}
