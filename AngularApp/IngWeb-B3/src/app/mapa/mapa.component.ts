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
    this.colocarChincheta(36,3);
  }

  setCenter(latitud: number, longitud: number) {
    var view = this.map.getView();
    view.setCenter(ol.proj.fromLonLat([longitud, latitud]));
    view.setZoom(8);
  }

  colocarChincheta(latitud: number, longitud: number) {
    var markers = new ol.layer.Vector({
      source: new ol.source.Vector(),
      style: new ol.style.Style({
        image: new ol.style.Icon({
          anchor: [0.5, 1],
          scale: 0.05,
          src: 'https://cdn-icons-png.flaticon.com/512/25/25613.png'
        })
      })
    });
    this.map.addLayer(markers);

    var marker = new ol.Feature(new ol.geom.Point(ol.proj.fromLonLat([longitud, latitud])));
    markers.getSource().addFeature(marker);
  }

}
