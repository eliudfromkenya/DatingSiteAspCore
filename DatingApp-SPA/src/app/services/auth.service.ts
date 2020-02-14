import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { JwtHelperService } from "@auth0/angular-jwt";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: "root"
})
export class AuthService {
  baseUrl = "https://localhost:5001/api/auth/";
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient) {}
  login(model: any) {
    console.log(model);
    return this.http.post(this.baseUrl + "login", model).pipe(
      map((resp: any) => {
        const user = resp;
        if (user) {
          localStorage.setItem("token", user.token);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
        }
      })
    );
  }

  loggedIn() {
    const token = localStorage.getItem("token");
    return !this.jwtHelper.isTokenExpired(token);
  }
  register(model: any) {
    return this.http.post(this.baseUrl + "register", model);
  }
}
