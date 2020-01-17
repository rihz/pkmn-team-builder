import { Component } from '@angular/core';
import { ThemeService } from './shared/theme/theme.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Pokemon Team Builder';

  constructor(private themeService: ThemeService) {
    
  }

  
}
