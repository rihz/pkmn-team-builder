import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'pkmn-type',
  templateUrl: './type.component.html',
  styleUrls: ['./type.component.scss']
})
export class TypeComponent implements OnInit {
  @Input() name: string;

  constructor() { }

  ngOnInit() {
  }

  get typeName(): string {
    return this.name !== null ? this.name.toLowerCase() : '';
  }
}
