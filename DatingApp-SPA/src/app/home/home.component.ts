import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"]
})
export class HomeComponent implements OnInit {
  inRegisterMode = false;
  animals: any;
  constructor(private http: HttpClient) {}

  ngOnInit() {
    //this.getValues();
  }

  registerToggle() {
    this.inRegisterMode = !this.inRegisterMode;
  }
}
