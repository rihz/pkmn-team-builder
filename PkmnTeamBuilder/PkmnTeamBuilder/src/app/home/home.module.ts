import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { ThemeService } from '../shared/theme/theme.service';
import { UserService } from "../shared/services/user.service";
import { HomeComponent } from "./home.component";
import { NewsService } from '../shared/services/news.service';
import { MatExpansionModule } from '@angular/material';

@NgModule({
    declarations: [HomeComponent],
    imports: [
        CommonModule,
        SharedModule,
        FormsModule,
        MatExpansionModule
    ],
    exports: [],
    providers: [ThemeService, UserService, NewsService]
})
export class HomeModule { }