import { Injectable } from '@angular/core';
import {BehaviorSubject} from "rxjs";
import {ApiService} from "./api.service";
import * as Console from "console";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly route = 'User';
  private responseSource = new BehaviorSubject<object>({});
  public response = this.responseSource.asObservable();
  constructor(private readonly apiService: ApiService) { }

  getUserWithQueryParams(id = {}) {
    return this.apiService.get(this.route + '/user/', { id });
  }

  getAllUsers() {
    return this.apiService.get(this.route + '/user/allusers');
  }

  changeprofilepicture(userID:any, newId:string) {
    return this.apiService.patch(this.route + '/changepicture/' + userID + '/' + newId);
  }

  getUserIdByUsername(username:any){
    return this.apiService.get(this.route + '/userid', {username});
  }

}
