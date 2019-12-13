import { Component, OnInit, Input } from '@angular/core';
import { Ability, Pokemon } from '../../shared/models';
import { FormControl } from '@angular/forms';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { MatDialog } from '@angular/material';
import { SelectorComponent } from '../selector/selector.component';

@Component({
  selector: 'supp-info',
  templateUrl: './supp-info.component.html',
  styleUrls: ['./supp-info.component.scss'],
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
  ]
})
export class SuppInfoComponent implements OnInit {
  @Input() member: Pokemon;

  selectedAbility: Ability = null;

  abilityControl = new FormControl();

  get selectedState() {
    return this.selectedAbility ? 'active' : 'inactive';
  }

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
  }

  select() {
    const ref = this.dialog.open(SelectorComponent, {
      width: '600px',
      data: {
        displayedColumns: ['name', 'description'],
        selections: this.member.abilities
      }
    });

    ref.afterClosed().subscribe(ability => {
      this.selectedAbility = ability;
    })
  }

}
