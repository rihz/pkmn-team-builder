import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'pkmn-type',
  templateUrl: './type.component.html',
  styleUrls: ['./type.component.scss']
})
export class TypeComponent implements OnInit {
  @Input() name: string;
  @Input() small: boolean = false;

  constructor() { }

  ngOnInit() {

  }

  get typeName(): string {
    let css = this.small ? 'small ' : '';
    
    return this.name !== null ? css + this.name.toLowerCase() : '';
  }
}
