import { Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { User } from "../models/user";

@Injectable({
  providedIn: "root"
})
export class UserService {
  baseUrl = environment.apiUrl + "/users";
  constructor(private http: HttpClient) {}

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl);
  }

  getUser(userId: number): Observable<User> {
    console.log("Getting user", userId);
    return this.http.get<User>(this.baseUrl + "/" + userId);
  }
}
