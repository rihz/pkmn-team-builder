import { Component, OnInit, Input } from '@angular/core';
import { Pokemon } from 'src/app/shared/models';
import { TeamMember } from '../../shared/models';

@Component({
  selector: 'basic-info',
  templateUrl: './basic-info.component.html',
  styleUrls: ['./basic-info.component.scss']
})
export class BasicInfoComponent implements OnInit {
  @Input() member: TeamMember;

  constructor() { }

  ngOnInit() {
    
  }

}
