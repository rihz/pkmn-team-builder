import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Team } from 'src/app/shared/models';
import { TeamMember } from '../../shared/models';
import { Router } from '@angular/router';

@Component({
  selector: 'team-card',
  templateUrl: './team-card.component.html',
  styleUrls: ['./team-card.component.scss']
})
export class TeamCardComponent implements OnInit {
  @Input() team: Team;
  selectedMember: TeamMember = null;
  @Output() onDelete = new EventEmitter<Team>();

  constructor(private router: Router) { }

  ngOnInit() {
  }

  selectMember(member: TeamMember) {
    this.selectedMember = this.selectedMember === member
      ? null
      : member;
  }

  delete() {
    this.onDelete.emit(this.team);
  }

  edit() {
    this.router.navigate([`/build/${this.team.code}`]);
  }

}
