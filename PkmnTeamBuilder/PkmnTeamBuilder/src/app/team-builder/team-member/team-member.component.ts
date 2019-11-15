import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'team-member',
  templateUrl: './team-member.component.html',
  styleUrls: ['./team-member.component.scss']
})
export class TeamMemberComponent implements OnInit {
  @Input() member: any;

  constructor() { }

  ngOnInit() {
    console.log(this.member);
  }

}
