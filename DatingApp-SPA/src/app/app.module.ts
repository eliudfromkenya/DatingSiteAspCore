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

import { AppComponent } from "./app.component";
import { NavComponent } from "./nav/nav.component";
import { FormsModule } from "@angular/forms";
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
    MemberDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    TabsModule.forRoot(),
    NgxGalleryModule,
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
    MemberListResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
