import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReservaService } from '../services/reserva.service';
import { UsuarioService } from '../services/usuario.service';
import { ViviendaService } from '../services/vivienda.service';

@Component({
  selector: 'app-vivienda-details',
  templateUrl: './vivienda-details.component.html',
  styleUrls: ['./vivienda-details.component.css']
})
export class ViviendaDetailsComponent implements OnInit {

  vivienda: any = null;
  fechaEntrada: string = "";
  fechaSalida: string = "";
  nPersonas: number = 0;
  puedeReservar: boolean = false;

  constructor(private route: ActivatedRoute,
    private usuarioService: UsuarioService,
    private viviendasService: ViviendaService,
    private reservaService: ReservaService) { }

  ngOnInit(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));

    this.viviendasService.getViviendaById(id)
    .subscribe(data => 
      {
        this.vivienda = data;
        console.log(this.vivienda)
      });
  }

  getReservaByFecha(fechaEntrada: string, fechaSalida: string){
    this.reservaService.getReservaByFechas(fechaEntrada, fechaSalida)
    .subscribe(data => 
      {
        this.vivienda = data;
        console.log(this.vivienda);
      });
  }

  


}
