import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material';
import { PkmnSelectorComponent } from '../pkmn-selector/pkmn-selector.component';

@Component({
  selector: 'add-pkmn',
  templateUrl: './add-pkmn.component.html',
  styleUrls: ['./add-pkmn.component.scss']
})
export class AddPkmnComponent implements OnInit {
  @Output() onAdd: EventEmitter<any> = new EventEmitter<any>();

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
  }

  showDialog() {
    const ref = this.dialog.open(PkmnSelectorComponent, {
      width: '600px',
      panelClass: 'pokemon-selector'
    });

    ref.afterClosed().subscribe(x => {
      if(x) {
        this.onAdd.emit(x);
      }
    })
  }

}
