import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ViviendaService {

  constructor(private http: HttpClient) { 
    
  }

  getViviendas(){

  }

  createVivivenda(){

  }

  getViviendaById(){

  }

  updateVivienda(){

  }

  deleteVivienda(){

  }

  getViviendaByPropietario(){

  }

  getViviendaByLocalidad(){

  }

}
