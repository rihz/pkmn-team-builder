import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Pokemon, Item, Nature, TeamMember } from '../../shared/models';
import { MatDialog } from '@angular/material';
import { PkmnSelectorComponent } from '../pkmn-selector/pkmn-selector.component';
import { NotesComponent } from '../notes/notes.component';
import { BooleanDialogComponent } from '../../shared/boolean-dialog/boolean-dialog.component';

@Component({
  selector: 'team-member',
  templateUrl: './team-member.component.html',
  styleUrls: ['./team-member.component.scss']
})
export class TeamMemberComponent implements OnInit {
  @Input() member: TeamMember;
  @Input() items: Item[];
  @Input() natures: Nature[];
  @Output() onRemove = new EventEmitter<any>();
  @Output() onChange = new EventEmitter<any>();

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
    
  }

  remove() {
    const ref = this.dialog.open(BooleanDialogComponent, {
      width: '600px',
      data: {
        message: 'Are you sure you would like to remove this Pokemon?'
      }
    });

    ref.afterClosed().subscribe(result => {
      if(result) {
        this.onRemove.emit(this.member);
      }
    })
  }

  replace() {
    const ref = this.dialog.open(PkmnSelectorComponent, {
      width: '600px',
      panelClass: 'pokemon-selector'
    });

    ref.afterClosed().subscribe(x => {
      if(x) {
        this.onChange.emit(x);
      }
    });
  }

  openNotes() {
    const ref = this.dialog.open(NotesComponent, {
      width: '600px',
      data: {
        notes: this.member.notes
      }
    });

    ref.afterClosed().subscribe(notes => {
      this.member.notes = notes;
    });
  }

  validate() {
    
  }
}
