import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'ev-display',
  templateUrl: './ev-display.component.html',
  styleUrls: ['./ev-display.component.scss']
})
export class EvDisplayComponent implements OnInit {
  @Input() stat: string;
  @Input() value: number;
  @Input() first: boolean = false;
  
  constructor() { }

  ngOnInit() {
  }

}
