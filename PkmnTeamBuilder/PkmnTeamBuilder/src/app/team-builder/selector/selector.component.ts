import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-selector',
  templateUrl: './selector.component.html',
  styleUrls: ['./selector.component.scss']
})
export class SelectorComponent implements OnInit {
  selections: any[];

  constructor(private ref: MatDialogRef<SelectorComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.selections = this.data.selections;
  }

  select(selection: any) {
    this.ref.close(selection);
  }

  search(value: string) {
    this.selections = this.data.selections
      .filter((val, index, array) => {
        return val.name.toLowerCase().indexOf(value.toLowerCase()) > -1;
      });
  }

  handleEnter() {
    if(this.selections.length > 0) {
      this.ref.close(this.selections[0]);
    }
  }

}
