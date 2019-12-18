import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-nickname-entry',
  templateUrl: './nickname-entry.component.html',
  styleUrls: ['./nickname-entry.component.scss']
})
export class NicknameEntryComponent implements OnInit {
  nickname = '';

  constructor(private ref: MatDialogRef<NicknameEntryComponent>) { }

  ngOnInit() {

  }

  finish() {
    this.ref.close(this.nickname);
  }
}
