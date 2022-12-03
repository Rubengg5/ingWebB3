import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from '../../environments/environment';
import { MapaComponent } from '../mapa/mapa.component';
import { ReservaService } from '../services/reserva.service';
import { UsuarioService } from '../services/usuario.service';
import { ViviendaService } from '../services/vivienda.service';


@Component({
  selector: 'app-vivienda-details',
  templateUrl: './vivienda-details.component.html',
  styleUrls: ['./vivienda-details.component.css']
})
export class ViviendaDetailsComponent implements OnInit {
  mapComponent : MapaComponent;
  vivienda: any = null;
  fechaEntrada: string = "";
  fechaSalida: string = "";
  latitudVivienda: number = 0;
  longitudVivienda: number = 0;
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
        console.log(this.vivienda);
        this.latitudVivienda = this.vivienda.ubicacion.lat;
        this.longitudVivienda = this.vivienda.ubicacion.lon;
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

  getImageURL(url: string): string{
    return environment.cloudinaryURL + url;
  }

}
