import { Component, OnInit } from '@angular/core';
import { Ability } from '../../shared/models';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'supp-info',
  templateUrl: './supp-info.component.html',
  styleUrls: ['./supp-info.component.scss']
})
export class SuppInfoComponent implements OnInit {
  abilities: Ability[] = [
    { id: 1, name: 'Ability 1', description: 'abcd'},
    { id: 2, name: 'Ability 2', description: 'abcdefg'}
  ];

  abilityControl = new FormControl();
  constructor() { }

  ngOnInit() {
  }

}
