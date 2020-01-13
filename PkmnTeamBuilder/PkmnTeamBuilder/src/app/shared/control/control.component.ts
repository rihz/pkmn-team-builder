import { Component, OnInit, Input, ViewChild, ElementRef, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-control',
  templateUrl: './control.component.html',
  styleUrls: ['./control.component.scss']
})
export class ControlComponent implements OnInit {
  @Input() label: string;
  @Input() value: any;
  @ViewChild('valueInput', null) input: ElementRef;
  @Output() touched = new EventEmitter<boolean>();

  editing = false;

  constructor() { }

  ngOnInit() {
    
  }

  edit() {
    this.editing = true;

    setTimeout(() => {
      this.input.nativeElement.focus();
    });
  }

  save() {
    this.editing = false;

    this.touched.emit(true);
  }

}
