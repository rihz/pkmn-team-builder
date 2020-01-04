import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TeamBuilderComponent } from './team-builder.component';

export const builderRoute: ModuleWithProviders = RouterModule.forChild([
    { path: '', component: TeamBuilderComponent },
    { path: ':code', component: TeamBuilderComponent }
]);