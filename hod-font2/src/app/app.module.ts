
// materials
import { MatNativeDateModule } from '@angular/material/core';
import { MatTabsModule } from '@angular/material/tabs';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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

import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
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
import { HodModalComponent } from './hod-modal/hod-modal.component';
import { HodShowAcPlanComponent } from './hod-show-ac-plan/hod-show-ac-plan.component';

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
    HodModalComponent,
    HodShowAcPlanComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,

    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
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

    MatProgressBarModule,
    MatProgressSpinnerModule,

    // DemoMaterialModule,
    MatNativeDateModule,
    ReactiveFormsModule,

  ],
  providers: [ShareService, SnackBarComponent, MatDialog],
  bootstrap: [AppComponent],
  entryComponents: [HodModalComponent]
})
export class AppModule { }
