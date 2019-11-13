import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PkmnSelectorComponent } from './pkmn-selector/pkmn-selector.component';
import { GenSelectorComponent } from './gen-selector/gen-selector.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule, MatInputModule, MatButtonModule } from '@angular/material';
import { PkmnService } from '../shared/services/pkmn.service';
import { TeamBuilderComponent } from './team-builder.component';



@NgModule({
  declarations: [TeamBuilderComponent, PkmnSelectorComponent, GenSelectorComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  providers: [PkmnService]
})
export class TeamBuilderModule { }
