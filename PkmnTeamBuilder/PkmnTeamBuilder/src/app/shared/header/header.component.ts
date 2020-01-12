import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { ThemeService } from '../theme/theme.service';
import { MatDialog } from '@angular/material';
import { ThemeSelectorComponent } from '../theme-selector/theme-selector.component';

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  _activeTheme: string = '';

  constructor(public userService: UserService, 
    private router: Router,
    private themeService: ThemeService,
    private dialog: MatDialog) { }

  get activeTheme() {
    return this._activeTheme;
  }

  set activeTheme(value: string) {
    this._activeTheme = value;

    this.themeService.setTheme(value);
  }

  get showHeader() {
    return this.router.url !== '/account/login'
      && this.router.url !== '/register';
  }

  get logo(): string {
    return this.themeService.getLogoUrl();
  }

  ngOnInit() {
    const settings = JSON.parse(localStorage.getItem('settings'));
    
    if(settings.theme) {
      this.activeTheme = settings.theme;
    }
  }

  logout() {
    this.userService.logout();

    this.router.navigate(['/account/login']);
  }

  changeTheme() {
    const ref = this.dialog.open(ThemeSelectorComponent, {
      width: '600px',
      panelClass: 'theme-panel'
    });

    ref.afterClosed().subscribe(themeName => {
      if(themeName !== '') {
        this.activeTheme = themeName;

        const userId = localStorage.getItem('userId');
        const settings = JSON.parse(localStorage.getItem('settings'));

        let newSettings = {
          userId: userId,
          ...settings
        };
        newSettings.theme = themeName;

        this.userService.changeSettings(newSettings);
      }
    });
  }

}
