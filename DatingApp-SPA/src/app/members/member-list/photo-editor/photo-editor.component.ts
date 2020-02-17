import { AuthService } from "src/app/services/auth.service";
import { environment } from "./../../../../environments/environment";
import { Input, Output, EventEmitter } from "@angular/core";
import { Component, OnInit } from "@angular/core";
import { Photo } from "src/app/models/Photo";
import { FileUploader } from "ng2-file-upload";
import { UserService } from 'src/app/services/user.service';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: "app-photo-editor",
  templateUrl: "./photo-editor.component.html",
  styleUrls: ["./photo-editor.component.css"]
})
export class PhotoEditorComponent implements OnInit {
  @Input() photos: Photo[];
  @Output() getMemberPhotoChange = new EventEmitter<string>();
  uploader: FileUploader;
  hasBaseDropZoneOver: boolean;
  response: string;
  baseUrl: string = environment.apiUrl + "/";
  currentMain: Photo;

  constructor(private authService: AuthService, private userService: UserService,
    private alertify: AlertifyService) {
    this.hasBaseDropZoneOver = false;
  }

  ngOnInit() {
    this.initializeUploader();
  }

  fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  initializeUploader() {
    this.response = "";
    this.uploader = new FileUploader({
      url:
        this.baseUrl +
        "users/" +
        this.authService.decodedToken.nameid +
        "/photos",
      authToken: "Bearer " + localStorage.getItem("token"),
      isHTML5: true,
      allowedFileType: ["image"],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });
    this.uploader.onAfterAddingFile = file => (file.withCredentials = false);

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const res: Photo = JSON.parse(response);
        const photo = {
          id: res.id,
          url: res.url,
          dateAdded: res.dateAdded,
          description: res.description,
          isMain: res.isMain
          // isApproved: res.isApproved
        };
        this.photos.push(photo);
        if (photo.isMain) {
          //  this.authService.changeMemberPhoto(photo.url);
          //   this.authService.currentUser.photoUrl = photo.url;
          // localStorage.setItem('user', JSON.stringify(this.authService.currentUser));
        }
      }
    };
  }


  setMainPhoto(photo: Photo) {
    this.userService.setMainPhoto(this.authService.decodedToken.nameid, photo.id).subscribe(() => {
      this.currentMain = this.photos.filter(p => p.isMain === true)[0];
      this.currentMain.isMain = false;
      photo.isMain = true;
      //this.authService.changeMemberPhoto(photo.url);
      //this.authService.currentUser.photoUrl = photo.url;
      //localStorage.setItem('user', JSON.stringify(this.authService.currentUser));
    }, error => {
      this.alertify.error(error);
    });
  }
  //this.uploader.response.subscribe(res => (this.response = res));
}
