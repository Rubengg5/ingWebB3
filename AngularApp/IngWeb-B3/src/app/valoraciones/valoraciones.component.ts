import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Console } from 'console';
import { Usuario } from '../models/usuario';
import { Valoracion } from '../models/valoracion';
import { UsuarioService } from '../services/usuario.service';
import { ValoracionService } from '../services/valoracion.service';
import {v4 as uuidv4} from 'uuid';

@Component({
  selector: 'app-valoraciones',
  templateUrl: './valoraciones.component.html',
  styleUrls: ['./valoraciones.component.css'],
})
export class ValoracionesComponent implements OnInit {
  valoraciones: any;
  nombreUsuario: any;
  responseOK: boolean;
  idVivienda: any;
  usuarios: any;

  newValoracion: Valoracion = {
    id: "",
    autor: "",
    descripcion: "",
    puntuacion: 0,
    vivienda: ''
  }

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private valoracionesService: ValoracionService,
    private usuariosService: UsuarioService
  ) {}

  ngOnInit(): void {
    this.responseOK = false;
    this.idVivienda = String(this.route.snapshot.paramMap.get('id'));
    this.valoracionesService.getValoracionesByVivienda(this.idVivienda).subscribe((data) => {
      this.valoraciones = data;
      console.log("Valoraciones: " + this.valoraciones);
    });
  }

  getUsuario(autor: string): string {
    this.usuariosService
      .getUsuarioById(autor)
      .subscribe((data) => {
        this.nombreUsuario = data.userName;
        console.log(this.nombreUsuario);
      });
      return this.nombreUsuario;
  }

  getUsuarios() {
    this.usuariosService
      .getUsuarios()
      .subscribe((data) => {
        this.usuarios = data;
      });
  }

  createValoracion() {
    this.newValoracion.id = uuidv4();
    this.newValoracion.vivienda = this.idVivienda;
    this.newValoracion.autor = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
    this.valoracionesService.createValoracion(this.newValoracion).subscribe(data => 
    {
        this.responseOK = data !== null;
    });

    if(this.responseOK){
      window.location.reload();
      // this.router.navigate(['/vivienda', this.newValoracion.vivienda])
    }
  }
}
