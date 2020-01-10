import { Component, OnInit, Input } from '@angular/core';
import { TeamMember, Move } from '../models';

@Component({
  selector: 'member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.scss']
})
export class MemberCardComponent implements OnInit {
  @Input() member: TeamMember;
  showDelay = 500;

  constructor() { }

  ngOnInit() {
  }

  getIVs(member: TeamMember): string {
    return `${member.hpIV} | ${member.atkIV} | ${member.defIV} | ${member.spatkIV} | ${member.spdefIV} | ${member.speIV}`;
  }

  getEVs(member: TeamMember): string {
    return `${member.hpEV} | ${member.atkEV} | ${member.defEV} | ${member.spatkEV} | ${member.spdefEV} | ${member.speEV}`;
  }

  getNatureTooltip(member: TeamMember): string {
    return `${member.nature.increase} is increased | ${member.nature.decrease} is decreased`;
  }

  getMoveTooltip(move: Move): string {
    return `${move.categoryName.toUpperCase()}\n${move.description}`;
  }
}
