import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Theme, ALL_THEMES } from '../theme/symbols';
import { charmanderTheme, bulbasaurTheme, squirtleTheme, pikachuTheme, umbreonTheme, celebiTheme } from '../theme/theme';

@Component({
  selector: 'app-theme-selector',
  templateUrl: './theme-selector.component.html',
  styleUrls: ['./theme-selector.component.scss']
})
export class ThemeSelectorComponent implements OnInit {
  themes: Theme[] = ALL_THEMES;

  constructor(private ref: MatDialogRef<ThemeSelectorComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
  }

  getBg(theme: Theme) {
    return theme.properties['--bg'];
  }

  getMemberBg(theme: Theme) {
    return theme.properties['--member-bg'];
  }

  getHeader(theme: Theme) {
    return theme.properties['--header'];
  }

  getHeaderColor(theme: Theme) {
    return theme.properties['--header-color'];
  }

  getBorder(theme: Theme) {
    return '1px solid ' + theme.properties['--border'];
  }

  getButton(theme: Theme) {
    return theme.properties['--button'];
  }

  getButtonColor(theme: Theme) {
    return theme.properties['--button-color'];
  }

  select(theme: Theme) {
    this.ref.close(theme.name);
  }

}
