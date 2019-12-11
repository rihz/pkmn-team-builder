import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PkmnSelectorComponent } from './pkmn-selector/pkmn-selector.component';
import { GenSelectorComponent } from './gen-selector/gen-selector.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, NgControl } from '@angular/forms';
import { MatFormFieldModule, MatInputModule, MatButtonModule, MatIconModule, MatDialogModule, MatCheckboxModule, MatChipsModule } from '@angular/material';
import { PkmnService } from '../shared/services/pkmn.service';
import { TeamBuilderComponent } from './team-builder.component';
import { AddPkmnComponent } from './add-pkmn/add-pkmn.component';
import { TeamMemberComponent } from './team-member/team-member.component';
import { BasicInfoComponent } from './basic-info/basic-info.component';
import { TypeComponent } from './type/type.component';
import { SuppInfoComponent } from './supp-info/supp-info.component';



@NgModule({
  declarations: [TeamBuilderComponent, PkmnSelectorComponent, GenSelectorComponent, AddPkmnComponent, TeamMemberComponent, BasicInfoComponent, TypeComponent, SuppInfoComponent],
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
    MatChipsModule
  ],
  providers: [PkmnService],
  entryComponents: [PkmnSelectorComponent]
})
export class TeamBuilderModule { }
