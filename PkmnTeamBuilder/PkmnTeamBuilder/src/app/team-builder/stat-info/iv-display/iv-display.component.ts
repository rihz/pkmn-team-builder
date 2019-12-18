import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TeamMember } from '../../../shared/models';

@Component({
  selector: 'iv-display',
  templateUrl: './iv-display.component.html',
  styleUrls: ['./iv-display.component.scss']
})
export class IvDisplayComponent implements OnInit {
  @Input() stat: string;
  @Input() value: number;
  @Input() first: boolean = false;
  @Output() onChange: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  changeIV(e: any) {
    let iv = e.target.valueAsNumber;

    if(e.target.value > 31) {
      iv = 31;
      this.value = 31;
    } else if(e.target.value < 0) {
      iv = 0;
      this.value = 0;
    }

    this.onChange.emit(iv);
  }

}
