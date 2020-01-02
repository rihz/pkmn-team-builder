import { Directive, OnInit, OnDestroy, Input, ElementRef, Inject } from "@angular/core";
import { Subject } from "rxjs";
import { takeUntil } from 'rxjs/operators';
import { ThemeService } from "./theme.service";
import { DOCUMENT } from "@angular/common";
import { Theme } from "./symbols";

@Directive({
    selector: '[theme]'
})
export class ThemeDirective implements OnInit, OnDestroy {
    @Input() scoped = false;

    private _destroy$ = new Subject();

    constructor(
        private _elementRef: ElementRef,
        private _themeService: ThemeService,
        @Inject(DOCUMENT) private _document: any
    ) { }

    ngOnInit() {
        const active = this._themeService.getActiveTheme();

        if(active) {
            this.updateTheme(active);
        }

        this._themeService.themeChange
            .pipe(takeUntil(this._destroy$))
            .subscribe((theme: Theme) => this.updateTheme(theme));
    }

    ngOnDestroy() {
        this._destroy$.next();
        this._destroy$.complete();
    }

    updateTheme(theme: Theme) {
        const element = this.getElement();
        
        for(const key in theme.properties) {
            element.style.setProperty(key, theme.properties[key]);
        }

        for(const name of this._themeService.theme) {
            element.classList.remove(`${theme.name}-theme`);
        }

        element.classList.add(`${theme.name}-theme`);
    }

    getElement() {
        return this.scoped ? this._elementRef.nativeElement : this._document.body;
    }
}