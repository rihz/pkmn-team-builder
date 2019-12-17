import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'total-display',
  templateUrl: './total-display.component.html',
  styleUrls: ['./total-display.component.scss']
})
export class TotalDisplayComponent implements OnInit {
  @Input() stat: string;
  @Input() evs: number;
  @Input() ivs: number;
  @Input() increased = false;
  @Input() decreased = false;
  @Input() baseStat: number;
  @Input() first: boolean = false;

  level = 50;

  get natureValue() {
    if(this.increased) {
      return 1.1;
    } else if(this.decreased) {
      return 0.9;
    } else {
      return 1;
    }
  }
  
  constructor() { }

  ngOnInit() {
  }

  get calc() {
    const evCalc = this.evs / 4;

    switch(this.stat.toLowerCase()) {
      case 'hp':
        const baseCalc = ((2 * this.baseStat + this.ivs + evCalc) * this.level) / 100;
        return Math.floor(baseCalc + this.level + 10);

      default:
        const statCalc = ((((2 * this.baseStat + this.ivs + evCalc) * this.level) / 100) + 5);
        return Math.floor(statCalc * this.natureValue);
        
    }
  }

}
