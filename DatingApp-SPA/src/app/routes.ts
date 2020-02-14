import { AuthGuard } from "./RouteGuards/auth.guard";
import { MessagesComponent } from "./messages/messages.component";
import { HomeComponent } from "./home/home.component";
import { Routes } from "@angular/router";
import { MemberListComponent } from "./member-list/member-list.component";
import { ListComponent } from "./list/list.component";
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
    canActivate: [AuthGuard]
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
