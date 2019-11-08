import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../shared/services/user.service';
import { UserRegistration } from '../../shared/models';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  errors: string;
  isRequesting: boolean;
  submitted = false;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {

  }

  registerUser({ value, valid }: { value: UserRegistration, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    
    if (valid) {
      this.userService.register(value.email, value.password);
    }
  }

  validateEmail(value: string) {
    const regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

    return regex.test(value);
  }

  validatePassword(value: string) {
    const regex = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z])/;

    return regex.test(value) && value.length > 4;
  }

  validateConfirm(value: string, toConfirm: string) {
    return value === toConfirm;
  }

}