import { Component, OnInit, Input, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-nickname-entry',
  templateUrl: './nickname-entry.component.html',
  styleUrls: ['./nickname-entry.component.scss']
})
export class NicknameEntryComponent implements OnInit {
  nickname = '';

  constructor(private ref: MatDialogRef<NicknameEntryComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.nickname = this.data.nickname;
  }

  finish() {
    this.ref.close(this.nickname);
  }
}
