import { Component, OnInit, Input } from '@angular/core';
import { Pokemon, Nature } from '../../shared/models';
import { MatDialog } from '@angular/material';
import { SelectorComponent } from '../selector/selector.component';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'stat-info',
  templateUrl: './stat-info.component.html',
  styleUrls: ['./stat-info.component.scss'],
  animations: [
    trigger("selected", [
      state('active', style({
        transform: 'translateX(-90%)'
      })),
      state('inactive', style({
        transform: 'translateX(0%)'
      })),
      transition('inactive <=> active', animate('500ms ease-in')),
    ]),
    trigger("fade", [
      state('active', style({
        opacity: 1
      })),
      state('inactive', style({
        opacity: 0
      })),
      transition('inactive <=> active', animate('500ms 500ms ease-in')),
    ])
  ]
})
export class StatInfoComponent implements OnInit {
  @Input() member: Pokemon;
  @Input() natures: Nature[];

  statType: string = 'BASE STATS';
  hpEV = 0;
  atkEV = 0;
  defEV = 0;
  spatkEV = 0;
  spdefEV = 0;
  speEV = 0;

  selectedNature: Nature = null;

  get selectedNatureState() {
    return this.selectedNature ? 'active' : 'inactive';
  }

  constructor(private dialog: MatDialog) { }

  ngOnInit() {

  }

  selectNature() {
    const ref = this.dialog.open(SelectorComponent, {
      width: '600px',
      data: {
        displayedColumns: ['name', 'increase', 'decrease'],
        selections: this.natures
      },
      panelClass: 'selector-panel'
    });

    ref.afterClosed().subscribe(nature => {
      this.selectedNature = nature;
    })
  }

}
