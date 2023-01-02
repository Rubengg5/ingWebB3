import { Component, OnInit } from '@angular/core';
import { ICreateOrderRequest } from "ngx-paypal";
import { environment } from 'src/environments/environment';
import { Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-paypal',
  templateUrl: './paypal.component.html',
  styleUrls: ['./paypal.component.css']
})


export class PaypalComponent implements OnInit {
  @Output() status = new EventEmitter<string>();
  public payPalConfig: any;
  public showPaypalButtons: boolean;

  

  constructor() { }

  ngOnInit(): void {
    this.payPalConfig = {
      currency: "EUR",
      clientId: environment.paypalClientId,
      createOrder: (data : any)=>
        <ICreateOrderRequest>{
          intent: "CAPTURE",
          purchase_units: [
            {
              amount: {
                currency_code: "EUR",
                value: "9.99",
                breakdown: {
                  item_total: {
                    currency_code: "EUR",
                    value: "9.99"
                  }
                }
              },
              items: [
                {
                  name: "Enterprise Subscription",
                  quantity: "1",
                  category: "DIGITAL_GOODS",
                  unit_amount: {
                    currency_code: "EUR",
                    value: "9.99"
                  }
                }
              ]
            }
          ]
        },
      advanced: {
        commit: "true"
      },
      style: {
        label: "paypal",
        layout: "vertical"
      },
      onApprove: (data: any, actions: any) => {
        console.log(
          "onApprove - transaction was approved, but not authorized",
          data,
          actions
        );
        actions.order.get().then((details: any) => {
          console.log(
            "onApprove - you can get full order details inside onApprove: ",
            details
          );
          this.status.emit("APPR");
        });
      },
      onClientAuthorization:(data : any)=> {
        console.log(
          "onClientAuthorization - you should probably inform your server about completed transaction at this point",
          data
        );
        this.status.emit("AUTH");
        console.log("Gracias", data.payer.name.given_name, ", su ID de pago es:", data.id )
      },
      onCancel: (data: any, actions: any) => {
        console.log("OnCancel", data, actions);
        this.status.emit("CANC");
      },
      onError: (err: any) => {
        console.log("OnError", err);
        this.status.emit("ERRO");
      },
      onClick: (data: any, actions : any) => {
        console.log("onClick", data, actions);
      }
    };
  }
 
  pay() {
    this.showPaypalButtons = true;
  }
 
  back(){
    this.showPaypalButtons = false;
  }
}


