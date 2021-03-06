import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Team } from '../../shared/models';
import { TeamMember } from '../models';
import { Router } from '@angular/router';
import { ConfigService } from '../services/config.service';
import { MatSnackBar } from '@angular/material';

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
  @Output() onFilterUser = new EventEmitter<string>();
  @Output() onChangeLike = new EventEmitter<number>();

  constructor(private router: Router,
    private config: ConfigService,
    private snackBar: MatSnackBar) { }

  get liked(): boolean {
    const userId = localStorage.getItem('userId');

    if(userId) {
      return this.team.likedBy.findIndex(x => x === userId) > -1;
    } else {
      return false;
    }
  }

  get ownedTeam(): boolean {
    const userId = localStorage.getItem('userId');

    if(userId) {
      return this.team.userId === userId;
    } else {
      return false;
    }
  }

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
    this.snackBar.open(
      'Link copied to clipboard',
      null,
      {
        duration: 1000,
        panelClass: 'snack'
      }
    );
  }

  filterByUser(userName: string) {
    this.onFilterUser.emit(userName);
  }

  updateLike() {
    this.onChangeLike.emit(this.team.id);
  }

}
