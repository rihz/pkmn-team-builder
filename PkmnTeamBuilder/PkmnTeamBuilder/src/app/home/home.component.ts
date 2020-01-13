import { Component, OnInit } from '@angular/core';
import { ThemeService } from '../shared/theme/theme.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(
    private themeService: ThemeService
  ) { }

  ngOnInit() {
  }

  getBgLogo() {
    return this.themeService.getBgLogoUrl();
  }

}
