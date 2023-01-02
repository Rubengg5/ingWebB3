import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Reserva } from '../models/reserva';
import { ReservaService } from '../services/reserva.service';
import { UsuarioService } from '../services/usuario.service';
import { ViviendaService } from '../services/vivienda.service';

@Component({
  selector: 'app-reservas',
  templateUrl: './reservas.component.html',
  styleUrls: ['./reservas.component.css']
})
export class ReservasComponent implements OnInit {

  reservaList: Reserva[] = [];
  imagenesList: any[] =[];
  
  constructor(private route: ActivatedRoute, private usuarioService: UsuarioService,
    private reservasService: ReservaService, private viviandasService: ViviendaService) { }

  ngOnInit(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));

    this.reservasService.getReservaByInquilino(id)
    .subscribe(data => 
      {
        this.reservaList = data;
        this.reservaList.forEach(element => {
          this.viviandasService.getViviendaById(element.idVivienda).subscribe(data =>{
            this.imagenesList.push([element, data]);
          })
        });
        console.log(this.reservaList)
        console.log(this.imagenesList)
      });

  }

  searchByDate(fechaEntrada: string, fechaSalida: string){
    this.reservasService.getReservaByFechas(fechaEntrada, fechaSalida)
    .subscribe(data =>
      {
        this.reservaList = data;
      });
  }

}
