import { Component } from "@angular/core";
import { Order } from "../../models/order.model";
import { Router } from "@angular/router";

@Component({
  templateUrl: "checkoutSummary.component.html"
})
export class CheckoutSummaryComponent {
  constructor(private router: Router,
    public order: Order) {
    if (order.payment.cardNumber == null
      || order.payment.cardExpiry == null
      || order.payment.cardSecurityCode == null) {
      router.navigateByUrl("/checkout/step2");
    }
  }
  submitOrder() {
    this.order.submit();
    this.router.navigateByUrl("/checkout/confirmation");
  }
}
