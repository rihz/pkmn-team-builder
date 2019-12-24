import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-boolean-dialog',
  templateUrl: './boolean-dialog.component.html',
  styleUrls: ['./boolean-dialog.component.scss']
})
export class BooleanDialogComponent implements OnInit {

  constructor(private ref: MatDialogRef<BooleanDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
  }

  close(result: boolean) {
    this.ref.close(result);
  }

}
