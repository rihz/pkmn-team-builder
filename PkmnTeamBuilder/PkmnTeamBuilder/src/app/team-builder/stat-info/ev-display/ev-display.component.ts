import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'ev-display',
  templateUrl: './ev-display.component.html',
  styleUrls: ['./ev-display.component.scss']
})
export class EvDisplayComponent implements OnInit {
  @Input() stat: string;
  @Input() value: number;
  @Input() first: boolean = false;
  @Output() onChange: EventEmitter<number> = new EventEmitter<number>();
  
  constructor() { }

  ngOnInit() {
  }

  changeEV(e: any) {
    let ev = e.target.valueAsNumber;

    if(e.target.value > 252) {
      ev = 252;
      this.value = 252;
    } else if(e.target.value < 0) {
      ev = 0;
      this.value = 0;
    }

    this.onChange.emit(ev);
  }

}
