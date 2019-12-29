import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountModule } from './account/account.module';
import { AuthGuard } from './auth.guard';
import { HttpClientModule } from '@angular/common/http';
import { ConfigService } from './shared/services/config.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TeamBuilderComponent } from './team-builder/team-builder.component';
import { TeamBuilderModule } from './team-builder/team-builder.module';
import { ThemeModule } from './shared/theme/theme.module';
import { charmanderTheme, squirtleTheme, bulbasaurTheme, pikachuTheme } from './shared/theme/theme';
import { TeamViewerModule } from './team-viewer/team-viewer.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AccountModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    TeamBuilderModule,
    TeamViewerModule,
    ThemeModule.forRoot({
      themes: [charmanderTheme, squirtleTheme, bulbasaurTheme, pikachuTheme],
      active: 'charmander'
    })
  ],
  providers: [ConfigService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
