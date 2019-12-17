import { Component, OnInit, Input } from '@angular/core';
import { Ability, Pokemon, Item } from '../../shared/models';
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
export class SuppInfoComponent implements OnInit {
  @Input() member: Pokemon;
  @Input() items: Item[];

  selectedAbility: Ability = null;
  selectedItem: Item = null;

  get selectedAbilityState() {
    return this.selectedAbility ? 'active' : 'inactive';
  }

  get selectedItemState() {
    return this.selectedItem ? 'active' : 'inactive';
  }

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
    
  }

  selectAbility() {
    const ref = this.dialog.open(SelectorComponent, {
      width: '600px',
      data: {
        displayedColumns: ['name', 'description'],
        selections: this.member.abilities
      },
      panelClass: 'selector-panel'
    });

    ref.afterClosed().subscribe(ability => {
      this.selectedAbility = ability;
    })
  }

  selectItem() {
    const ref = this.dialog.open(SelectorComponent, {
      width: '600px',
      data: {
        displayedColumns: ['name', 'description'],
        selections: this.items
      },
      panelClass: 'selector-panel'
    });

    ref.afterClosed().subscribe(item => {
      this.selectedItem = item;
    })
  }

}
