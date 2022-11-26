import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Reserva } from '../models/reserva';
import { ReservaService } from '../services/reserva.service';
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-reservas',
  templateUrl: './reservas.component.html',
  styleUrls: ['./reservas.component.css']
})
export class ReservasComponent implements OnInit {

  reservaList: Reserva[] = [];
  
  constructor(private route: ActivatedRoute, private usuarioService: UsuarioService,
    private reservasService: ReservaService) { }

  ngOnInit(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));

    this.reservasService.getReservaByInquilino(id)
    .subscribe(data => 
      {
        this.reservaList = data;
        console.log(this.reservaList);
      });
  }

}
