import { environment } from "./../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { JwtHelperService } from "@auth0/angular-jwt";
import { map } from "rxjs/operators";
import { User } from '../models/user';

@Injectable({
  providedIn: "root"
})
export class AuthService {
  baseUrl = environment.apiUrl + "/auth/";
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: User;

  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http.post(this.baseUrl + "login", model).pipe(
      map((resp: any) => {
        const user = resp;
        if (user) {
          localStorage.setItem("token", user.token);
          localStorage.setItem("user", JSON.stringify(user.user));
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          this.currentUser = user.user;        }
      })
    );
  }

  loggedIn() {
    const token = localStorage.getItem("token");
    return !this.jwtHelper.isTokenExpired(token);
  }
  logout() {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    this.currentUser = null;
    this.decodedToken = null;
  }

  register(model: any) {
    return this.http.post(this.baseUrl + "register", model);
  }
}
