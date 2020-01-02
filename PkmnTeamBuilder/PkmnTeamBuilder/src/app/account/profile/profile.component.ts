import { Component, OnInit } from '@angular/core';
import { User } from '../../shared/models';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  touched = false;
  
  constructor(public userService: UserService) { }

  ngOnInit() {

  }

}
