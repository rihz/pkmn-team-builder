import { Component, OnInit, Input } from '@angular/core';
import { Pokemon, Item, Nature } from 'src/app/shared/models';

@Component({
  selector: 'team-member',
  templateUrl: './team-member.component.html',
  styleUrls: ['./team-member.component.scss']
})
export class TeamMemberComponent implements OnInit {
  @Input() member: Pokemon;
  @Input() items: Item[];
  @Input() natures: Nature[];

  constructor() { }

  ngOnInit() {
    
  }

}
