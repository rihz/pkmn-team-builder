import { Component, OnInit, Input } from '@angular/core';
import { TeamMember, Move } from 'src/app/shared/models';
import { MatDialog } from '@angular/material';
import { SelectorComponent } from '../selector/selector.component';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'move-info',
  templateUrl: './move-info.component.html',
  styleUrls: ['./move-info.component.scss'],
  animations: [
    trigger("fadeOut", [
      state('active', style({
        opacity: 0,
        display: 'none'
      })),
      state('inactive', style({
        opacity: 1
      })),
      transition('inactive => active', animate('500ms')),
    ]),
    trigger("fadeIn", [
      state('active', style({
        opacity: 1
      })),
      state('inactive', style({
        opacity: 0
      })),
      transition('inactive <=> active', animate('500ms 1000ms ease-in')),
    ]),
    trigger("show", [
      state('inactive', style({
        display: 'none'
      })),
      state('active', style({
        display: 'block'
      })),
      transition('inactive => active', animate('500ms 500ms'))
    ])
  ]
})
export class MoveInfoComponent implements OnInit {
  @Input() member: TeamMember;

  constructor(private dialog: MatDialog) { }

  get move1State() {
    return this.member.move1 ? 'active' : 'inactive';
  }
  get move2State() {
    return this.member.move2 ? 'active' : 'inactive';
  }
  get move3State() {
    return this.member.move3 ? 'active' : 'inactive';
  }
  get move4State() {
    return this.member.move4 ? 'active' : 'inactive';
  }

  ngOnInit() {
  }

  selectMove1() {
    const ref = this.dialog.open(SelectorComponent, {
      width: '650px',
      data: {
        displayedColumns: ['name', 'category', 'description', 'pp', 'power', 'accuracy', 'type'],
        selections: this.member.pokemon.moves
      },
      panelClass: 'selector-panel'
    });

    ref.afterClosed().subscribe(move => {
      this.member.move1 = move;
      this.member.move1Id = move.id;
    });
  }

  selectMove2() {
    const ref = this.dialog.open(SelectorComponent, {
      width: '650px',
      data: {
        displayedColumns: ['name', 'category', 'description', 'pp', 'power', 'accuracy', 'type'],
        selections: this.member.pokemon.moves
      },
      panelClass: 'selector-panel'
    });

    ref.afterClosed().subscribe(move => {
      this.member.move2 = move;
      this.member.move2Id = move.id;
    });
  }

  selectMove3() {
    const ref = this.dialog.open(SelectorComponent, {
      width: '650px',
      data: {
        displayedColumns: ['name', 'category', 'description', 'pp', 'power', 'accuracy', 'type'],
        selections: this.member.pokemon.moves
      },
      panelClass: 'selector-panel'
    });

    ref.afterClosed().subscribe(move => {
      this.member.move3 = move;
      this.member.move3Id = move.id;
    });
  }

  selectMove4() {
    const ref = this.dialog.open(SelectorComponent, {
      width: '650px',
      data: {
        displayedColumns: ['name', 'category', 'description', 'pp', 'power', 'accuracy', 'type'],
        selections: this.member.pokemon.moves
      },
      panelClass: 'selector-panel'
    });

    ref.afterClosed().subscribe(move => {
      this.member.move4 = move;
      this.member.move4Id = move.id;
    });
  }

}
