import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Order } from "../models/order.model";
@Component({
  template: `
<table *ngIf="orders && orders.length > 0; else nodata" class="table table-striped">
  <tbody>
    <tr>
      <th>Customer</th><th>Address</th><th>Products</th>
      <th>Total</th><th></th>
    </tr>
    <tr *ngFor="let o of orders">
      <td>{{o.name}}</td>
      <td>{{o.address}}</td>
      <td>{{o.products.length}}</td>
      <!--<td>{{o.payment.total | currency:"USD":"symbol"}}</td>-->
      <td *ngIf="!o.shipped; else shipped">
       <button class="btn btn-sm btn-primary" (click)="markShipped(o)">Ship</button>
      </td>
    </tr>
  </tbody>
</table>
<ng-template #shipped>
 <td>Shipped</td>
</ng-template>
<ng-template #nodata>
 <h3 class="text-center">There are no orders</h3>
</ng-template>
`
})
export class OrderAdminComponent {
  constructor(private repo: Repository) { }

  get orders(): Order[] {
    return this.repo.orders;
  }

  markShipped(order: Order) {
    this.repo.shipOrder(order);
  }
}
