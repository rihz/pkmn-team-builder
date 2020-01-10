import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Team } from '../../shared/models';
import { TeamMember } from '../models';
import { Router } from '@angular/router';
import { ConfigService } from '../services/config.service';

@Component({
  selector: 'team-card',
  templateUrl: './team-card.component.html',
  styleUrls: ['./team-card.component.scss']
})
export class TeamCardComponent implements OnInit {
  @Input() team: Team;
  @Input() canDelete = false;
  @Input() canEdit = false;
  @Input() canLink = false;
  @Input() expandAll = false;
  selectedMembers: TeamMember[] = [];
  @Output() onDelete = new EventEmitter<Team>();

  constructor(private router: Router,
    private config: ConfigService) { }

  get teamUrl(): string {
    return this.config.getBaseURL() + `/teams/${this.team.code}`;
  }

  ngOnInit() {
    if(this.expandAll) {
      Object.assign(this.selectedMembers, this.team.members);
    }
  }

  selectMember(member: TeamMember) {
    const found = this.selectedMembers.findIndex(x => x.id === member.id);

    if(found > -1) {
      this.selectedMembers.splice(found, 1);
    } else {
      this.selectedMembers.push(member);
    }
  }

  delete() {
    this.onDelete.emit(this.team);
  }

  edit() {
    this.router.navigate([`/build/${this.team.code}`]);
  }

  copyLink(payload: string) {
    alert(payload + ' has been copied');
  }

}
