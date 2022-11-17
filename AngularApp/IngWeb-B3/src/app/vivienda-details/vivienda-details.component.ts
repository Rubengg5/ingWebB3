import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UsuarioService } from '../services/usuario.service';
import { ViviendaService } from '../services/vivienda.service';

@Component({
  selector: 'app-vivienda-details',
  templateUrl: './vivienda-details.component.html',
  styleUrls: ['./vivienda-details.component.css']
})
export class ViviendaDetailsComponent implements OnInit {

  vivienda: any = null;

  constructor(private route: ActivatedRoute,
    private usuarioService: UsuarioService,
    private viviendasService: ViviendaService) { }

  ngOnInit(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));

    this.viviendasService.getViviendaByPropietario(id)
    .subscribe(data => 
      {
        this.vivienda = data;
      });
  }

  


}
