import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { CloudinaryModule } from '@cloudinary/ng';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { TestPabloComponent } from './test-pablo/test-pablo.component';

@NgModule({
  declarations: [
    AppComponent,
    TestPabloComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule,
    RouterModule.forRoot([]),
    CloudinaryModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
