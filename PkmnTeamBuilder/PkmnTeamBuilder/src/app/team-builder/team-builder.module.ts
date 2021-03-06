import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PkmnSelectorComponent } from './pkmn-selector/pkmn-selector.component';
import { GenSelectorComponent } from './gen-selector/gen-selector.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, NgControl } from '@angular/forms';
import { MatFormFieldModule, MatInputModule, MatButtonModule, MatIconModule, MatDialogModule, MatCheckboxModule, MatChipsModule, MatTabsModule, MatTableModule, MatCardModule, MatTooltipModule, MatGridListModule, MatRadioModule, MatSelectModule, MatOptionModule, MatSnackBarModule } from '@angular/material';
import { PkmnService } from '../shared/services/pkmn.service';
import { TeamBuilderComponent } from './team-builder.component';
import { AddPkmnComponent } from './add-pkmn/add-pkmn.component';
import { TeamMemberComponent } from './team-member/team-member.component';
import { BasicInfoComponent } from './basic-info/basic-info.component';
import { SuppInfoComponent } from './supp-info/supp-info.component';
import { SelectorComponent } from './selector/selector.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StatInfoComponent } from './stat-info/stat-info.component';
import { StatDisplayComponent } from './stat-info/stat-display/stat-display.component';
import { EvDisplayComponent } from './stat-info/ev-display/ev-display.component';
import { IvDisplayComponent } from './stat-info/iv-display/iv-display.component';
import { TotalDisplayComponent } from './stat-info/total-display/total-display.component';
import { NicknameEntryComponent } from './basic-info/nickname-entry/nickname-entry.component';
import { MoveInfoComponent } from './move-info/move-info.component';
import { DisplayCardComponent } from '../shared/display-card/display-card.component';
import { MoveDisplayComponent } from './move-info/move-display/move-display.component';
import { NotesComponent } from './notes/notes.component';
import { builderRoute } from './team-builder.routing';
import { TeamService } from '../shared/services/team.service';
import { MemberService } from '../shared/services/member.service';
import { UserService } from '../shared/services/user.service';
import { CodeDisplayComponent } from './code-display/code-display.component';



@NgModule({
  declarations: [TeamBuilderComponent, PkmnSelectorComponent, GenSelectorComponent, AddPkmnComponent, TeamMemberComponent, BasicInfoComponent, SuppInfoComponent, SelectorComponent, StatInfoComponent, StatDisplayComponent, EvDisplayComponent, IvDisplayComponent, TotalDisplayComponent, NicknameEntryComponent, MoveInfoComponent, MoveDisplayComponent, NotesComponent, CodeDisplayComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatCheckboxModule,
    MatChipsModule,
    MatTabsModule,
    MatTableModule,
    MatCardModule,
    MatTooltipModule,
    MatGridListModule,
    MatRadioModule,
    MatSelectModule,
    MatOptionModule,
    builderRoute,
    MatSnackBarModule
  ],
  providers: [
    PkmnService,
    TeamService,
    MemberService,
    UserService
  ],
  entryComponents: [
    PkmnSelectorComponent,
    SelectorComponent,
    NicknameEntryComponent,
    NotesComponent,
    CodeDisplayComponent
  ]
})
export class TeamBuilderModule { }
