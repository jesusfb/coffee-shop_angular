import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Router } from "@angular/router";
import { AuthenticationService } from "./authentication.service";

@Injectable()
export class AuthenticationGuard {
  constructor(private router: Router, private authService: AuthenticationService) { }

  canActivateChild(route: ActivatedRouteSnapshot/*, state: RouterStateSnapshot*/): boolean {
    if (this.authService.authenticated) {
      return true; // доступ разрешен
    } else {
      this.authService.callbackUrl = route.url.toString();
      this.router.navigateByUrl("/admin/login");
      return false; // доступ запрещен
    }
  }
}
