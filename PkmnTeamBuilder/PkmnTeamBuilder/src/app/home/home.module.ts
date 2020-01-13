import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { ThemeService } from '../shared/theme/theme.service';
import { UserService } from "../shared/services/user.service";
import { HomeComponent } from "./home.component";

@NgModule({
    declarations: [HomeComponent],
    imports: [
        CommonModule,
        SharedModule,
        FormsModule
    ],
    exports: [],
    providers: [ThemeService, UserService]
})
export class HomeModule { }