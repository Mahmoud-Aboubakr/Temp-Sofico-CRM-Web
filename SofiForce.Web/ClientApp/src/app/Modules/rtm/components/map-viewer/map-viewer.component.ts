import { Component, OnInit } from '@angular/core';
import { DynamicDialogConfig } from 'primeng/dynamicdialog';
import { GeoPoint } from 'src/app/core/Models/DtoModels/GeoPoint';

declare var google: any;

@Component({
  selector: 'app-map-viewer',
  templateUrl: './map-viewer.component.html',
  styleUrls: ['./map-viewer.component.scss']
})
export class MapViewerComponent implements OnInit {

  options: any;
  overlays: any[];

  Points:GeoPoint[]=[];
  constructor(
    private config: DynamicDialogConfig,
  ) { 

    if (this.config.data) {
      if (this.config.data.Points) {
        this.Points=this.config.data.Points
      }
    }
  }

  ngOnInit(): void {

    this.options = {
      center: { lat: 30.065774, lng: 31.338034 },
      zoom: 12,
      mapId: '2df52e872b9212a'
    };

    this.overlays = [

    ];


    this.Points.forEach(element => {
      this.overlays.push(new google.maps.Marker({ position: { lat: element.lat, lng: element.lng }, title: '', icon:'assets/images/marker_icon_offline.png', data: 0}))
    });

    if (this.Points.length > 0) {
      this.options.center = this.Points[0];
    }
  }

}
