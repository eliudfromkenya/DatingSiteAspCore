import { AuthService } from "./services/auth.service";
import { Component, OnInit } from "@angular/core";
import { JwtHelperService } from "@auth0/angular-jwt";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent implements OnInit {
  constructor(private authService: AuthService) {}
  jwtHelper = new JwtHelperService();
  title = "DatingApp-SPA";
  ngOnInit(): void {
    const token = localStorage.getItem("token");
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }
  }
}
