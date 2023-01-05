import {Component, OnInit} from '@angular/core';
import {UserService} from "../../../core/services/user.service";

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit{
  public users:any = []

  constructor(private readonly userService: UserService) {
  }

  ngOnInit(): void {
    this.users = this.userService.getAllUsers().subscribe(data => this.users = data);
  }

}
