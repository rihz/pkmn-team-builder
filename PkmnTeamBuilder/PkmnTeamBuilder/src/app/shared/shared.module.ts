import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatIconModule, MatTableModule, MatMenuModule, MatCardModule, MatButtonToggleModule } from '@angular/material';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { BooleanDialogComponent } from './boolean-dialog/boolean-dialog.component';
import { ThemeSelectorComponent } from './theme-selector/theme-selector.component';

@NgModule({
  declarations: [HeaderComponent, BooleanDialogComponent, ThemeSelectorComponent],
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
    MatButtonToggleModule
  ],
  exports: [
    HeaderComponent
  ],
  entryComponents: [
    BooleanDialogComponent,
    ThemeSelectorComponent
  ]
})
export class SharedModule { }