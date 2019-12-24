import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatIconModule, MatTableModule, MatMenuModule } from '@angular/material';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { BooleanDialogComponent } from './boolean-dialog/boolean-dialog.component';

@NgModule({
  declarations: [HeaderComponent, BooleanDialogComponent],
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
    MatTableModule
  ],
  exports: [
    HeaderComponent
  ],
  entryComponents: [
    BooleanDialogComponent
  ]
})
export class SharedModule { }