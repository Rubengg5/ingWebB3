import { Component, OnInit } from '@angular/core';
// Import the Cloudinary classes.
import {Cloudinary, CloudinaryImage} from '@cloudinary/url-gen';
import {fill} from "@cloudinary/url-gen/actions/resize";

@Component({
  selector: 'app-test-pablo',
  templateUrl: './test-pablo.component.html',
  styleUrls: ['./test-pablo.component.css']
})
export class TestPabloComponent implements OnInit {
  exampleString: string;
  exampleArray: string[];
  img!: CloudinaryImage;


  constructor() {
    this.exampleArray = [];
    this.exampleString = "Hola!! Esto es Test-Pablo";
   }

  ngOnInit(): void {
        // Create a Cloudinary instance and set your cloud name.
        const cld = new Cloudinary({
          cloud: {
            cloudName: 'dee6pfpam'
          }
        });
        // Instantiate a CloudinaryImage object for the image with the public ID, 'docs/models'.
        this.img = cld.image('samples/bike');
    
        // Resize to 250 x 250 pixels using the 'fill' crop mode.
        this.img.resize(fill().width(250).height(250));
  }

}
