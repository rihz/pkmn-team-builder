import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Pokemon, Item, Nature, TeamMember } from '../../shared/models';
import { MatDialog } from '@angular/material';
import { PkmnSelectorComponent } from '../pkmn-selector/pkmn-selector.component';

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
    this.onRemove.emit(this.member);
  }

  replace() {
    const ref = this.dialog.open(PkmnSelectorComponent, {
      width: '600px'
    });

    ref.afterClosed().subscribe(x => {
      if(x) {
        this.onChange.emit({
          previous: this.member,
          next: x
        });
      }
    });
  }

  openNotes() {

  }
}
