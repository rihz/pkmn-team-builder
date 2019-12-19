import { Component, OnInit, Input } from '@angular/core';
import { Move } from '../../../shared/models';

@Component({
  selector: 'move',
  templateUrl: './move-display.component.html',
  styleUrls: ['./move-display.component.scss']
})
export class MoveDisplayComponent implements OnInit {
  @Input() move: Move;

  constructor() { }

  ngOnInit() {
  }

}
