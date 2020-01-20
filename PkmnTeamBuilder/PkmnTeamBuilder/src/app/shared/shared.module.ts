import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatIconModule, MatTableModule, MatMenuModule, MatCardModule, MatButtonToggleModule, MatProgressSpinnerModule, MatSpinner, MatTooltipModule, MatSnackBarModule, MatBadgeModule } from '@angular/material';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { BooleanDialogComponent } from './boolean-dialog/boolean-dialog.component';
import { ThemeSelectorComponent } from './theme-selector/theme-selector.component';
import { ControlComponent } from './control/control.component';
import { MemberCardComponent } from './member-card/member-card.component';
import { TypeComponent } from './type/type.component';
import { DisplayCardComponent } from './display-card/display-card.component';
import { CopyClipboardDirective } from './clipboard.directive';
import { TeamCardComponent } from './team-card/team-card.component';
import { AppInputComponent } from './app-input/app-input.component';

@NgModule({
  declarations: [
    HeaderComponent, 
    BooleanDialogComponent, 
    ThemeSelectorComponent, 
    ControlComponent, 
    MemberCardComponent,
    TypeComponent, 
    DisplayCardComponent, 
    CopyClipboardDirective,
    TeamCardComponent,
    AppInputComponent
  ],
  imports: [
    CommonModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    RouterModule,
    MatTableModule,
    MatCardModule,
    MatButtonToggleModule,
    MatProgressSpinnerModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatBadgeModule
  ],
  exports: [
    HeaderComponent,
    MatSpinner,
    ControlComponent,
    MemberCardComponent,
    TypeComponent,
    DisplayCardComponent,
    CopyClipboardDirective,
    TeamCardComponent,
    AppInputComponent
  ],
  entryComponents: [
    BooleanDialogComponent,
    ThemeSelectorComponent
  ]
})
export class SharedModule { }