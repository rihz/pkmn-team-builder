import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-code-display',
  templateUrl: './code-display.component.html',
  styleUrls: ['./code-display.component.scss']
})
export class CodeDisplayComponent implements OnInit {

  constructor(private ref: MatDialogRef<CodeDisplayComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private snackbar: MatSnackBar) { }

  ngOnInit() {
    
  }

  copyCode(payload: string) {
    this.snackbar.open(
      `${payload} was copied to clipboard`,
      null,
      {
        duration: 1000,
        panelClass: 'snack'
      }
    );
  }

}
