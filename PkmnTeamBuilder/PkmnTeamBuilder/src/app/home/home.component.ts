import { Component, OnInit } from '@angular/core';
import { ThemeService } from '../shared/theme/theme.service';
import { UserService } from '../shared/services/user.service';
import { NewsService } from '../shared/services/news.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  news: any;
  loading = true;

  constructor(
    private themeService: ThemeService,
    private userService: UserService,
    private newsService: NewsService
  ) { }

  get loggedIn(): boolean {
    return this.userService.isLoggedIn();
  }

  ngOnInit() {
    this.newsService.getNews()
      .subscribe(result => {
        this.news = result;
        this.loading = false;
      }, error => {
        alert(error);
        this.loading = false;
      });
  }

  getBgLogo() {
    return this.themeService.getBgLogoUrl();
  }

}
