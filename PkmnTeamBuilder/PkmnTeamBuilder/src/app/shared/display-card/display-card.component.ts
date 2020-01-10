import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'display-card',
  templateUrl: './display-card.component.html',
  styleUrls: ['./display-card.component.scss']
})
export class DisplayCardComponent implements OnInit {
  @Input() label: string;
  @Input() value: any;
  @Input() type: string;

  constructor() { }

  ngOnInit() {
  }

}
