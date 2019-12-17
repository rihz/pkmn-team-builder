import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'iv-display',
  templateUrl: './iv-display.component.html',
  styleUrls: ['./iv-display.component.scss']
})
export class IvDisplayComponent implements OnInit {
  @Input() stat: string;
  @Input() value: number;
  @Input() first: boolean = false;

  constructor() { }

  ngOnInit() {
  }

}
