import { Component, OnInit } from '@angular/core';
import { ThemeService } from '../shared/theme/theme.service';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  
  constructor(
    private themeService: ThemeService,
    private userService: UserService
  ) { }

  get loggedIn(): boolean {
    return this.userService.isLoggedIn();
  }

  ngOnInit() {
  }

  getBgLogo() {
    return this.themeService.getBgLogoUrl();
  }

}
