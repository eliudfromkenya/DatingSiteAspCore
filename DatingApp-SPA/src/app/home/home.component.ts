import { AuthService } from "src/app/services/auth.service";
import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"]
})
export class HomeComponent implements OnInit {
  inRegisterMode = false;
  alreadyMember = false;
  animals: any;
  constructor(private http: HttpClient, private authService: AuthService) {}

  ngOnInit() {
    if (this.authService.currentUser != null) {
      this.alreadyMember = true;
    }
  }

  registerToggle() {
    this.inRegisterMode = !this.inRegisterMode;
  }
}
