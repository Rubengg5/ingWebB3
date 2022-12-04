import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Reserva } from '../models/reserva';
import { ReservaService } from '../services/reserva.service';
import {v4 as uuidv4} from 'uuid';

@Component({
  selector: 'app-reserva-create',
  templateUrl: './reserva-create.component.html',
  styleUrls: ['./reserva-create.component.css']
})
export class ReservaCreateComponent implements OnInit {

  newReserva: Reserva = {
    id: "",
    idVivienda: "",
    fechaEntrada: "",
    fechaSalida: "",
    nPersonas: 1,
    inquilino: "28773b97-f6c5-40ee-96cd-f895b3f99028",
  }

  responseOK: boolean = false;

  constructor(private reservasService: ReservaService, private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.newReserva.idVivienda = String(this.route.snapshot.paramMap.get('id'));
  }

  createReserva(){
    this.newReserva.id = uuidv4();
    this.reservasService.createReserva(this.newReserva).subscribe(data => {
      console.log(data);
      this.responseOK = data !== null;
    });

    if(this.responseOK){
      this.router.navigate(['/reserva', this.newReserva.id])
    }
  }
}


