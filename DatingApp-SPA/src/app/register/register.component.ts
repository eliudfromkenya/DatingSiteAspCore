import { AuthService } from "./../services/auth.service";
import { Component, OnInit, Input } from "@angular/core";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"]
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Input() animalsFromHome: any;
  constructor(private authService: AuthService) {}

  ngOnInit() {}
  register() {
    this.authService.register(this.model).subscribe(
      () => console.log("registration successifull"),
      error => console.log(error)
    );
  }
  cancel() {
    console.log("cancel");
  }
}
