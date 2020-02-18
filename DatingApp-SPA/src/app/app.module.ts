import { FileUploadModule } from "ng2-file-upload";
import { PhotoEditorComponent } from "./members/member-list/photo-editor/photo-editor.component";
import { MemberEditComponent } from "./members/member-list/member-edit/member-edit.component";
import { NgxGalleryModule } from "@nomadreservations/ngx-gallery";
import { MemberListResolver } from "./resolvers/member-list.resolver";
import { MemberDetailComponent } from "./members/member-list/member-detail/member-detail.component";
import { MemberCardComponent } from "./members/member-list/member-card/member-card.component";
import { UserService } from "./services/user.service";
import { AuthGuard } from "./RouteGuards/auth.guard";
import { ErrorInterceptorProvider } from "./services/error.interceptor";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { TabsModule } from "ngx-bootstrap";
import { BsDatepickerModule } from "ngx-bootstrap/datepicker";
import { FormsModule } from "@angular/forms";
import { MomentModule } from 'ngx-moment';

import { AppComponent } from "./app.component";
import { NavComponent } from "./nav/nav.component";
import { ReactiveFormsModule } from "@angular/forms";
import { AuthService } from "./services/auth.service";
import { HomeComponent } from "./home/home.component";
import { RegisterComponent } from "./register/register.component";
import { AlertifyService } from "./services/alertify.service";
import { MemberListComponent } from "./members/member-list/member-list.component";
import { ListComponent } from "./list/list.component";
import { MessagesComponent } from "./messages/messages.component";
import { RouterModule } from "@angular/router";
import { appRoutes } from "./routes";
import { JwtModule } from "@auth0/angular-jwt";
import { MemberDetailResolver } from "./resolvers/member-details.resolver";
import { MemberEditResolver } from "./resolvers/member-edit.resolver";
import { PreventUnsavedChanges } from "./RouteGuards/prevent-unsaved-changes-guard";

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    MemberListComponent,
    ListComponent,
    MessagesComponent,
    MemberCardComponent,
    MemberDetailComponent,
    MemberEditComponent,
    PhotoEditorComponent,
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    MomentModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    TabsModule.forRoot(),
    NgxGalleryModule,
    FileUploadModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: function tokenGetter() {
          return localStorage.getItem("token");
        },
        whitelistedDomains: ["localhost:5001"],
        blacklistedRoutes: ["http://localhost:5001/auth/login"]
      }
    })
  ],
  providers: [
    AuthService,
    AlertifyService,
    AuthGuard,
    ErrorInterceptorProvider,
    UserService,
    MemberDetailResolver,
    MemberListResolver,
    MemberEditResolver,
    PreventUnsavedChanges
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
