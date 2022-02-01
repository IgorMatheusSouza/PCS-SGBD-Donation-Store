import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UserViewModel } from "../models/userViewModel";
import { BaseService } from "./baseService";

@Injectable({
  providedIn: 'root'
})

export class UserService extends BaseService {

  constructor(protected http: HttpClient) { super(http)}

  private urlAuthetication: string = this.Baseurl + 'user/';

  private urls = {
    get: this.urlAuthetication,
    registerPhone: this.urlAuthetication + 'phone/',
  }

  getUser() {
    return this.http.get<UserViewModel>(this.urls.get, this.header).pipe();
  }

  registerPhone(phone: string) {
    return this.http.post(this.urls.registerPhone,{phoneNumber: phone},this.header).pipe();
  }
}
