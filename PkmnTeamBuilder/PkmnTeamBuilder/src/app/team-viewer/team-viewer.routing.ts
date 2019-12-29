import { ModuleWithProviders } from "@angular/core";
import { RouterModule } from "@angular/router";
import { TeamViewerComponent } from "./team-viewer.component";

export const viewerRoute: ModuleWithProviders = RouterModule.forChild([
    { path: '', component: TeamViewerComponent }
])