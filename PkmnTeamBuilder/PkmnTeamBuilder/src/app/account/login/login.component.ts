import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from '../../shared/services/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Credentials } from 'src/app/shared/models';
import { ThemeService } from 'src/app/shared/theme/theme.service';
import { TeamService } from '../../shared/services/team.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {

  private subscription: Subscription;

  brandNew: boolean;
  errors: string;
  isRequesting: boolean;
  submitted = false;
  credentials: Credentials = { email: '', password: '', username: '' };
  loginError = '';
  linkCode = '';

  constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute,
    private themeService: ThemeService, private teams: TeamService) { }

  ngOnInit() {
    // subscribe to router event
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;

    this.subscription = this.activatedRoute.queryParams.subscribe(
      (param: any) => {
        this.brandNew = param.brandNew;
        this.credentials.email = param.email;
        this.loginError = param.loginError;
        this.linkCode = param.code;
      });
  }

  ngOnDestroy() {
    // prevent memory leak by unsubscribing
    this.subscription.unsubscribe();
  }

  login() {
      this.userService.login(this.credentials.username, this.credentials.password)
        .subscribe(result => {
          if (result) {
            const settings = result.settings;

            localStorage.setItem('auth_token', result.auth_token);
            localStorage.setItem('username', result.username);
            localStorage.setItem('userId', result.id);
            localStorage.setItem('email', result.email);
            localStorage.setItem('settings', JSON.stringify(settings));

            if(this.linkCode) {
              this.teams.linkTeam(this.linkCode, result.id)
                .subscribe(x => {
                  this.router.navigate(['/teams']);
                });
            } else {            
              this.router.navigate(['/teams']);
            }
          }
        }, errors => {
          this.errors = 'Username or password is incorrect';
        });
  }

}