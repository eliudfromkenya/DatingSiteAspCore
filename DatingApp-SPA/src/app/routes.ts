import { MemberEditComponent } from "./members/member-list/member-edit/member-edit.component";
import { MemberDetailComponent } from "./members/member-list/member-detail/member-detail.component";
import { AuthGuard } from "./RouteGuards/auth.guard";
import { MessagesComponent } from "./messages/messages.component";
import { HomeComponent } from "./home/home.component";
import { Routes } from "@angular/router";
import { MemberListComponent } from "./members/member-list/member-list.component";
import { ListsComponent } from "./list/list.component";
import { MemberDetailResolver } from "./resolvers/member-details.resolver";
import { MemberListResolver } from "./resolvers/member-list.resolver";
import { MemberEditResolver } from "./resolvers/member-edit.resolver";
import { PreventUnsavedChanges } from "./RouteGuards/prevent-unsaved-changes-guard";
import { ListsResolver } from "./resolvers/list.resolver";
import { MessagesResolver } from "./resolvers/messages.resolver";
export const appRoutes: Routes = [
  {
    path: "",
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
        component: MessagesComponent,
        resolve: { user: MessagesResolver }
      },
      {
        path: "member/edit",
        component: MemberEditComponent,
        resolve: { user: MemberEditResolver },
        canDeactivate: [PreventUnsavedChanges]
      },
      {
        path: "members/:id",
        component: MemberDetailComponent,
        resolve: { user: MemberDetailResolver }
      },
      {
        path: "lists",
        component: ListsComponent,
        resolve: { user: ListsResolver }
      }
    ]
  },
  {
    path: "**",
    redirectTo: "",
    pathMatch: "full"
  }
];
