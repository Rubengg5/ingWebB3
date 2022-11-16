import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Reserva } from '../models/reserva';
import { Usuario } from '../models/usuario';
import { Vivienda } from '../models/vivienda';
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  currentUser: any = null;
  listaViviendas: Vivienda[] = [];
  listaReservas: Reserva[] = [];

  constructor(private route: ActivatedRoute,
    private usuarioService: UsuarioService,) { }

  ngOnInit(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));
    
    this.usuarioService.getUsuarioById(id)
    .subscribe(data => 
      {
        this.currentUser = data;
      });
  }

  public getListaViviendas(){

  }


  public getListaReservas(){
    
  }
}
