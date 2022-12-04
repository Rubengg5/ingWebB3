import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ViviendaService } from '../services/vivienda.service';

@Component({
  selector: 'app-vivienda-modify',
  templateUrl: './vivienda-modify.component.html',
  styleUrls: ['./vivienda-modify.component.css']
})
export class ViviendaModifyComponent implements OnInit {

  vivienda: any = null;

  constructor(private viviendasService: ViviendaService, private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));
    this.viviendasService.getViviendaById(id)
    .subscribe(data =>
      {
        this.vivienda = data;
      });
  }

  modifyVivienda(){
    this.viviendasService.updateVivienda(this.vivienda)
    .subscribe(data =>
      {
        console.log(data);
      });
    this.router.navigate(['/vivienda', this.vivienda.id])
  }

  deleteVivienda(){
    this.viviendasService.deleteVivienda(this.vivienda)
    .subscribe(data => 
      {

      });
    this.router.navigate(['/viviendas', this.vivienda.propietario])
  }

}
