import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit {
  notes: string;

  constructor(private ref: MatDialogRef<NotesComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.notes = this.data.notes;
  }

  save() {
    this.ref.close(this.notes);
  }

  cancel() {
    this.ref.close(this.data.notes);
  }

}
