import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'team-builder',
  templateUrl: './team-builder.component.html',
  styleUrls: ['./team-builder.component.scss']
})
export class TeamBuilderComponent implements OnInit {
  gen = null;

  constructor() { }

  ngOnInit() {
  }

  setGen(gen: number) {
    this.gen = gen;
  }

}
