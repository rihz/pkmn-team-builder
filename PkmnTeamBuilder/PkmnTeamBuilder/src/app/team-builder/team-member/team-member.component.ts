import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Pokemon, Item, Nature, TeamMember } from '../../shared/models';

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

  constructor() { }

  ngOnInit() {
    
  }

  remove() {
    this.onRemove.emit(this.member);
  }

  replace() {

  }

  openNotes() {

  }
}
