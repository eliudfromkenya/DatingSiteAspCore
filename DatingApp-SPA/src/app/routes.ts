import { MemberDetailComponent } from "./members/member-list/member-detail/member-detail.component";
import { AuthGuard } from "./RouteGuards/auth.guard";
import { MessagesComponent } from "./messages/messages.component";
import { HomeComponent } from "./home/home.component";
import { Routes } from "@angular/router";
import { MemberListComponent } from "./members/member-list/member-list.component";
import { ListComponent } from "./list/list.component";
import { MemberDetailResolver } from "./resolvers/member-details.resolver";
import { MemberListResolver } from "./resolvers/member-list.resolver";
export const appRoutes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "home",
    component: HomeComponent
  },
  {
    path: "members",
    component: MemberListComponent,
    canActivate: [AuthGuard],
    resolve: { users: MemberListResolver }
  },
  {
    path: "",
    runGuardsAndResolvers: "always",
    canActivate: [AuthGuard],
    children: [
      {
        path: "messages",
        component: MessagesComponent
      },
      {
        path: "members/:id",
        component: MemberDetailComponent,
        resolve: { user: MemberDetailResolver }
      },
      {
        path: "lists",
        component: ListComponent
      }
    ]
  },
  {
    path: "**",
    redirectTo: "home",
    pathMatch: "full"
  }
];
