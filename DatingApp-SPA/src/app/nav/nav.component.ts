import { AlertifyService } from "./../services/alertify.service";
import { AuthService } from "./../services/auth.service";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.css"]
})
export class NavComponent implements OnInit {
  model: any = {};
  constructor(
    public authService: AuthService,
    private alertifyService: AlertifyService
  ) {}

  ngOnInit() {
    //this.logout();
  }

  login() {
    this.authService.login(this.model).subscribe(
      next => this.alertifyService.success("Successifully logged in"),
      err => this.alertifyService.error(err)
    );
  }

  loggedIn() {
    const token = localStorage.getItem("token");
    return !!token;
  }

  logout() {
    localStorage.removeItem("token");
    console.log("Logged out");
  }
}
