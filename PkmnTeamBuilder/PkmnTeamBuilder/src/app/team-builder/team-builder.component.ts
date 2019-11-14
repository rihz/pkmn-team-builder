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
    this.gen = localStorage.getItem('teamBuilderGen');
  }

  setGen(gen: number) {
    this.gen = gen;
    
    localStorage.setItem('teamBuilderGen', gen.toString());
  }

}
