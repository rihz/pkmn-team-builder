import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-input',
  templateUrl: './app-input.component.html',
  styleUrls: ['./app-input.component.scss']
})
export class AppInputComponent implements OnInit {
  @Input() label: string;
  @Input() password: boolean;
  value: string;
  @Output() changed = new EventEmitter<string>();

  constructor() { }

  get inputType(): string {
    return this.password ? 'password' : 'text';
  }

  ngOnInit() {
  }

  onChange(e: any) {
    this.changed.emit(e);
  }

}
