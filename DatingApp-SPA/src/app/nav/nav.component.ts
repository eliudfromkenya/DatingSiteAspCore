import { AlertifyService } from "./../services/alertify.service";
import { AuthService } from "./../services/auth.service";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.css"]
})
export class NavComponent implements OnInit {
  model: any = {};
  photoUrl: string;

  constructor(
    public authService: AuthService,
    private alertifyService: AlertifyService,
    private router: Router
  ) {}

  ngOnInit() {
    this.authService.currentPhotoUrl.subscribe(
      photoUrl => (this.photoUrl = photoUrl)
    );
  }

  login() {
    this.authService.login(this.model).subscribe(
      next => this.alertifyService.success("Successifully logged in"),
      err => this.alertifyService.error(err),
      () => this.router.navigate(["/members"])
    );
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    this.authService.logout();
    this.alertifyService.error("Successifully logged out");
    if (this.authService.loggedIn())
      this.alertifyService.error("Still logged in");
    this.router.navigate(["/home"]);
  }
}
