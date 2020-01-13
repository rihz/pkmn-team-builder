import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { ThemeService } from '../shared/theme/theme.service';

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        SharedModule,
        FormsModule
    ],
    exports: [],
    providers: [ThemeService]
})
export class HomeModule { }