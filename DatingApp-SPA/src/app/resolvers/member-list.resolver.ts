import { AlertifyService } from "./../services/alertify.service";
import {
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot
} from "@angular/router";
import { UserService } from "src/app/services/user.service";
import { Injectable } from "@angular/core";
import { Resolve } from "@angular/router";
import { User } from "../models/user";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";

@Injectable()
export class MemberListResolver implements Resolve<User[]> {
 pageNumber = 1;
 pageSize = 4;
 
  constructor(
    private userService: UserService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<User[]> {
    return this.userService.getUsers(this.pageNumber, this.pageSize).pipe(
      catchError(error => {
        this.alertify.error("Problem retrieving data");
        this.router.navigate(["/home"]);
        return of(null);
      })
    );
  }
}
