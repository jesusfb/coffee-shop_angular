import { Injectable } from "@angular/core";
import { Cart } from "./cart.model";
import { Repository } from "./repository";
import { NavigationStart, Router } from "@angular/router";
import { filter } from "rxjs/operators";

export class Payment {
  cardNumber: string = '';
  cardExpiry: string = '';
  cardSecurityCode: string = '';
}

export class CartLine {
  constructor(private productId: number,
    private quantity: number) { }
}

export class OrderConfirmation {
  constructor(public orderId: number = 0,
    public authCode: string = '',
    public amount: number = 0,
    public errorMessage: string = '') { }
}

type OrderSession = {
  name: string,
  address: string,
  cardNumber: string,
  cardExpiry: string,
  cardSecurityCode: string
}

@Injectable()
export class Order {
  name: string = '';
  address: string = '';
  payment: Payment = new Payment();
  submitted: boolean = false;
  shipped: boolean = false;
  orderConfirmation: OrderConfirmation = new OrderConfirmation();
  id?: number;

  constructor(private repo: Repository, public cart: Cart, router: Router) {
    router.events
      .pipe(filter(event => event instanceof NavigationStart))
      .subscribe(event => {
        if (router.url.startsWith("/checkout")
          && this.name != null && this.address != null) {
          repo.storeSessionData<OrderSession>("checkout", {
            name: this.name,
            address: this.address,
            cardNumber: this.payment.cardNumber,
            cardExpiry: this.payment.cardExpiry,
            cardSecurityCode: this.payment.cardSecurityCode
          });
        }
      });

    repo.getSessionData<OrderSession>("checkout").subscribe(data => {
      if (data != null) {
        this.name = data.name;
        this.address = data.address;
        this.payment.cardNumber = data.cardNumber;
        this.payment.cardExpiry = data.cardExpiry;
        this.payment.cardSecurityCode = data.cardSecurityCode;
      }
    });
  }

  get products(): CartLine[] {
    return this.cart.selections
      .map(p => new CartLine(p.productId!, p.quantity));
  }

  clear() {
    this.name = '';
    this.address = '';
    this.payment = new Payment();
    this.cart.clear();
    this.submitted = false;
  }

  submit() {
    this.submitted = true;
    this.repo.createOrder(this);
  }
}
