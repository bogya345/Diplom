
// materials
import { MatNativeDateModule } from '@angular/material/core';
import { MatTabsModule } from '@angular/material/tabs';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTableModule } from '@angular/material/table';
import { CdkTableModule } from '@angular/cdk/table';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button'
import { MatInputModule } from '@angular/material/input'

import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';

import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import {MatAutocompleteModule} from '@angular/material/autocomplete';

//


import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ShareService } from './share.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HodHomeComponent } from './hod-home/hod-home.component';
import { LoginComponent } from './login/login.component';

import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HodDepsComponent } from './hod-deps/hod-deps.component';
import { HodPromotionComponent } from './hod-promotion/hod-promotion.component';
import { HodAcplanComponent } from './hod-acplan/hod-acplan.component';
import { HodDepComponent } from './hod-dep/hod-dep.component';
import { SnackBarComponent } from './snack-bar/snack-bar.component';
import { HodPromoteComponent } from './hod-promote/hod-promote.component';
import { HodModalShowRequirsComponent } from './hod-modal-show-requirs/hod-modalShowRequirs.component';
import { HodShowAcPlanComponent } from './hod-show-ac-plan/hod-show-ac-plan.component';
import { HodModalReloadAcPlanComponent } from './hod-modal-reload-ac-plan/hod-modal-reload-ac-plan.component';
import { HodModalShowGroupStatusComponent } from './hod-modal-show-group-status/hod-modal-show-group-status.component';
import { HodModalPromoteComponent } from './hod-modal-promote/hod-modal-promote.component';
import { HodMapSubDepComponent } from './hod-map-sub-dep/hod-map-sub-dep.component';
import { HodShowDirPropertyComponent } from './hod-show-dir-property/hod-show-dir-property.component';
import { ProgressModalComponent } from './progress-modal/progress-modal.component';

@NgModule({
  declarations: [
    AppComponent,

    LoginComponent,

    HodHomeComponent,
    HodDepsComponent,
    HodPromotionComponent,
    HodAcplanComponent,
    HodDepComponent,
    SnackBarComponent,
    HodPromoteComponent,
    HodModalShowRequirsComponent,
    HodShowAcPlanComponent,
    HodModalReloadAcPlanComponent,
    HodModalShowGroupStatusComponent,
    HodModalPromoteComponent,
    HodMapSubDepComponent,
    HodShowDirPropertyComponent,
    ProgressModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,

    HttpClientModule,
    MatTabsModule,
    MatCardModule,
    MatGridListModule,
    MatSnackBarModule,
    MatExpansionModule,
    MatIconModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatTableModule,
    CdkTableModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,

    MatRadioModule,
    MatSelectModule,

    MatProgressBarModule,
    MatProgressSpinnerModule,

    MatNativeDateModule,

    FormsModule,
    ReactiveFormsModule,
    MatAutocompleteModule
  ],
  providers: [
    ShareService,
    SnackBarComponent,
    MatDialog,
    FormsModule,
    ReactiveFormsModule,
    {
      provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
      useValue: { appearance: 'fill' }
    }
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    HodModalShowRequirsComponent,
    HodShowAcPlanComponent,
    HodModalReloadAcPlanComponent,
    HodModalShowGroupStatusComponent,
    HodModalPromoteComponent,
    HodShowDirPropertyComponent,
    ProgressModalComponent
  ]
})
export class AppModule { }

