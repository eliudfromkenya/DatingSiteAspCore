import { AlertifyService } from './../../../services/alertify.service';
import { UserService } from 'src/app/services/user.service';
import { AuthService } from './../../../services/auth.service';
import { Component, OnInit, Input } from "@angular/core";
import { User } from "src/app/models/user";

@Component({
  selector: "app-member-card",
  templateUrl: "./member-card.component.html",
  styleUrls: ["./member-card.component.css"]
})
export class MemberCardComponent implements OnInit {
  @Input() user: User;
  constructor(private authService: AuthService, private userService: UserService, private alertify: AlertifyService) {}

  ngOnInit() {}

sendLike(id: number) {
  this.userService.sendLike(this.authService.decodedToken.nameid, id).subscribe(data => {
    this.alertify.success('You have liked: ' + this.user.knownAs);
  }, error => {
    this.alertify.error(error);
  });
}
}