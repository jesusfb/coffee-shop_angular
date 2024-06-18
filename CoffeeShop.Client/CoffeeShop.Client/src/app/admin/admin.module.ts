import { RouterModule, Routes } from "@angular/router";
import { AdminComponent } from "./admin.component";
import { ProductAdminComponent } from "./productAdmin.component";
import { OrderAdminComponent } from "./orderAdmin.component";
import { OverviewComponent } from "./overview.component";
import { FormsModule } from "@angular/forms";
import { NgModule } from "@angular/core";
import { AdminProductEditorComponent } from "./adminProductEditor.component";
import { CommonModule } from "@angular/common";
import { AuthenticationComponent } from "../auth/authentication.component";
import { AuthenticationGuard } from "../auth/authentication.guard";
import { AuthModule } from "../auth/auth.module";

const routes: Routes = [
  { path: "login", component: AuthenticationComponent },
  {
    path: "", component: AdminComponent,
    canActivateChild: [AuthenticationGuard],
    children: [
      { path: "products", component: ProductAdminComponent },
      { path: "orders", component: OrderAdminComponent },
      { path: "overview", component: OverviewComponent },
      { path: "", component: OverviewComponent }]
  }
];

@NgModule({
  imports: [RouterModule, FormsModule, RouterModule.forChild(routes), CommonModule, AuthModule], 
  declarations: [AdminComponent, OverviewComponent, ProductAdminComponent, OrderAdminComponent, AdminProductEditorComponent]
})
export class AdminModule { }
