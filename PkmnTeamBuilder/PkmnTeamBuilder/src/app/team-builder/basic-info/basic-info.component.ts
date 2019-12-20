import { Component, OnInit, Input } from '@angular/core';
import { Pokemon } from 'src/app/shared/models';
import { TeamMember } from '../../shared/models';
import { MatDialog } from '@angular/material';
import { NicknameEntryComponent } from './nickname-entry/nickname-entry.component';

@Component({
  selector: 'basic-info',
  templateUrl: './basic-info.component.html',
  styleUrls: ['./basic-info.component.scss']
})
export class BasicInfoComponent implements OnInit {
  @Input() member: TeamMember;

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
    
  }

  showDialog() {
    const ref = this.dialog.open(NicknameEntryComponent, {
      width: '300px',
      panelClass: 'nickname-panel',
      data: {
        nickname: this.member.nickname ? this.member.nickname : ''
      }
    });

    ref.afterClosed().subscribe(x => {
      if(x) {
        this.member.nickname = x;
      }
    })
  }

}
