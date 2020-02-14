import { AlertifyService } from "./../services/alertify.service";
import { Router } from "@angular/router";
import { AuthService } from "./../services/auth.service";
import { Injectable } from "@angular/core";
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree
} from "@angular/router";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
    private alertify: AlertifyService
  ) {}
  canActivate(): boolean {
    if (this.authService.loggedIn()) {
      return true;
    }
    this.alertify.error(
      "Prohibited point - please ensure you have rights or loged in to access the resource"
    );
    this.router.navigate(["/home"]);
    return false;
  }
}
