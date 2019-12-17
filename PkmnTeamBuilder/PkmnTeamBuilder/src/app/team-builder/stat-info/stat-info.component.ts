import { Component, OnInit, Input } from '@angular/core';
import { Pokemon } from '../../shared/models';

@Component({
  selector: 'stat-info',
  templateUrl: './stat-info.component.html',
  styleUrls: ['./stat-info.component.scss']
})
export class StatInfoComponent implements OnInit {
  @Input() member: Pokemon;
  statType: string = 'BASE STATS';
  hpEV = 0;
  atkEV = 0;
  defEV = 0;
  spatkEV = 0;
  spdefEV = 0;
  speEV = 0;

  constructor() { }

  ngOnInit() {

  }

}
