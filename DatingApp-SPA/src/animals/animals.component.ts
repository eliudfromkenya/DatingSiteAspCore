import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-animals",
  templateUrl: "./animals.component.html",
  styleUrls: ["./animals.component.css"]
})
export class AnimalsComponent implements OnInit {
  animals: any;
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getValues();
  }
  getValues() {
    this.http.get("https://localhost:5001/api/animals").subscribe(
      resp => {
        this.animals = resp;
      },
      error => {
        console.log(error);
      }
    );
  }
}
