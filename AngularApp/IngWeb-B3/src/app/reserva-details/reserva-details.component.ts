import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReservaService } from '../services/reserva.service';
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-reserva-details',
  templateUrl: './reserva-details.component.html',
  styleUrls: ['./reserva-details.component.css']
})
export class ReservaDetailsComponent implements OnInit {

  reserva: any = null;

  constructor(private route: ActivatedRoute,
    private usuarioService: UsuarioService,
    private reservasService: ReservaService) { }

  ngOnInit(): void {

    const id = String(this.route.snapshot.paramMap.get('id'));

    this.reservasService.getReservaById(id)
    .subscribe(data => 
      {
        this.reserva = data;
      });
  }

  public modificarReserva(): void {
    this.reservasService.updateReserva(this.reserva)
    .subscribe(data => 
      {
        this.reserva = data;
      });
  }

}
