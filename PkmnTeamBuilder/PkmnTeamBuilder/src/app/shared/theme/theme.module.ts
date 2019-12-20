import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Options } from 'selenium-webdriver';
import { ThemeOptions, THEMES, ACTIVE_THEME } from './symbols';
import { ThemeService } from './theme.service';
import { ThemeDirective } from './theme.directive';

@NgModule({
    imports: [CommonModule],
    providers: [ThemeService],
    declarations: [ThemeDirective],
    exports: [ThemeDirective]
})
export class ThemeModule {
    static forRoot(options: ThemeOptions): ModuleWithProviders {
        return {
            ngModule: ThemeModule,
            providers: [
                {
                    provide: THEMES,
                    useValue: options.themes
                },
                {
                    provide: ACTIVE_THEME,
                    useValue: options.active
                }
            ]
        }
    }
}