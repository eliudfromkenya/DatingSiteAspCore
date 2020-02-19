import { AuthService } from "./../../../services/auth.service";
import { UserService } from "./../../../services/user.service";
import { AlertifyService } from "./../../../services/alertify.service";
import { ActivatedRoute } from "@angular/router";
import { Component, OnInit, ViewChild, HostListener } from "@angular/core";
import { User } from "src/app/models/user";
import { NgForm } from "@angular/forms";

@Component({
  selector: "app-member-edit",
  templateUrl: "./member-edit.component.html",
  styleUrls: ["./member-edit.component.css"]
})
export class MemberEditComponent implements OnInit {
  user: User;
  photoUrl: string;

  @ViewChild("editForm") editForm: NgForm;
  @HostListener("window:beforeunload", ["$event"])
  unLoadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }
  constructor(
    private route: ActivatedRoute,
    private alertify: AlertifyService,
    private userService: UserService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => (this.user = data.user));
    this.authService.currentPhotoUrl.subscribe(url => (this.photoUrl = url));
  }

  updateUser() {
    this.userService
      .updateUser(this.authService.decodedToken.nameid, this.user)
      .subscribe(
        next => {
          this.alertify.success("Profile successifully updated");
          this.editForm.reset(this.user);
        },
        error => this.alertify.error(error)
      );
    console.log(this.user);
  }

  updateMainPhoto(photoUrl) {
    this.user.photoUrl = photoUrl;
  }
}
