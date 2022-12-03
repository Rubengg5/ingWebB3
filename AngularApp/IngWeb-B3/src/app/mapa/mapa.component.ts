import { Component, Input , OnInit } from '@angular/core';
declare var ol: any;

@Component({
  selector: 'app-mapa',
  templateUrl: './mapa.component.html',
  styleUrls: ['./mapa.component.css']
})

export class MapaComponent implements OnInit {
  @Input() latitud = -1;
  @Input() longitud = -1;
  map: any;
  constructor() { }
  /*latitude: number = 18.5204;
  longitude: number = 73.8567;*/

  ngOnInit(): void {
    this.map = new ol.Map({
      target: 'map',
      layers: [
        new ol.layer.Tile({
          source: new ol.source.OSM()
        })
      ],
      view: new ol.View({
        center: ol.proj.fromLonLat([0, 0]),
        zoom: 8
      })
    });
    this.setCenter(this.latitud, this.longitud);
  }

  setCenter(latitud: number, longitud: number) {
    var view = this.map.getView();
    view.setCenter(ol.proj.fromLonLat([longitud, latitud]));
    view.setZoom(8);
  }

}
