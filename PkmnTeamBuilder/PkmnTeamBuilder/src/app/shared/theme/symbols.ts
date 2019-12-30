import { InjectionToken } from '@angular/core';
import { charmanderTheme, squirtleTheme, bulbasaurTheme, pikachuTheme, celebiTheme, umbreonTheme, voltorbTheme } from './theme';

export const THEMES = new InjectionToken('THEMES');
export const ACTIVE_THEME = new InjectionToken('ACTIVE_THEME');
export const ALL_THEMES: Theme[] = [
    charmanderTheme,
    squirtleTheme,
    bulbasaurTheme,
    pikachuTheme,
    celebiTheme,
    umbreonTheme
]
export const CURRENT_THEME = 'umbreon';

export interface Theme {
    name: string;
    properties: any;
}

export interface ThemeOptions {
    themes: Theme[];
    active: string;
}