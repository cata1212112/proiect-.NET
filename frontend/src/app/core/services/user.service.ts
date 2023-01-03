import { Injectable } from '@angular/core';
import {BehaviorSubject} from "rxjs";
import {ApiService} from "./api.service";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly route = 'students';
  private responseSource = new BehaviorSubject<object>({});
  public response = this.responseSource.asObservable();
  constructor(private readonly apiService: ApiService) { }

  getUserWithQueryParams(id = {}) {
    return this.apiService.get(this.route + '/user/', { id });
  }

  getAllUsers() {
    return this.apiService.get(this.route + '/user/allusers');
  }

}
