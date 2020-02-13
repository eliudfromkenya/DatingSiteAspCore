import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: "root"
})
export class AuthService {
  baseUrl = "https://localhost:5001/api/auth/";
  constructor(private http: HttpClient) {}
  login(model: any) {
    console.log(model);
    return this.http.post(this.baseUrl + "login", model).pipe(
      map((resp: any) => {
        const user = resp;
        console.log("user:", user);

        if (user) {
          localStorage.setItem("token", user.token);
        }
      })
    );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + "register", model);
  }
}
