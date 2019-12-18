import { Component, OnInit, Input } from '@angular/core';
import { TeamMember, Move } from 'src/app/shared/models';
import { MatDialog } from '@angular/material';
import { SelectorComponent } from '../selector/selector.component';

@Component({
  selector: 'move-info',
  templateUrl: './move-info.component.html',
  styleUrls: ['./move-info.component.scss']
})
export class MoveInfoComponent implements OnInit {
  @Input() member: TeamMember;

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
  }

  selectMove1() {
    this.selectMove(this.member.pokemon.moves);
  }

  selectMove2() {

  }

  selectMove3() {

  }

  selectMove4() {

  }

  selectMove(moves: Move[]) {
    const ref = this.dialog.open(SelectorComponent, {
      width: '650px',
      data: {
        displayedColumns: ['name', 'category', 'description', 'pp', 'power', 'accuracy', 'type'],
        selections: moves
      },
      panelClass: 'selector-panel'
    })
  }

}
