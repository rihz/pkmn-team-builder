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
    TeamBuilderModule
  ],
  providers: [ConfigService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
