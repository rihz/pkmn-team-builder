import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'stat-display',
  templateUrl: './stat-display.component.html',
  styleUrls: ['./stat-display.component.scss']
})
export class StatDisplayComponent implements OnInit {
  @Input() stat: string;
  @Input() value: number;
  @Input() first: boolean = false;
  
  constructor() { }

  ngOnInit() {
  }

}
