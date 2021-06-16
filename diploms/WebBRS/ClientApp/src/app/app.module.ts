import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { JwtModule } from '@auth0/angular-jwt';
import { ConfirmationDialog } from './dialog-body/confirmation-dialog.component';
import { AlertDialogComponent } from './dialog-body/alert-dialog/alert-dialog.component';
import { VERSION, MatDialogRef,   MatDialog, MatSnackBar,  MAT_DIALOG_DATA, MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material';

import { AppComponent } from './app.component';
import { environment } from '../environments/environment';
import { ACCESS_TOKEN_KEY } from './_services/auth.service';

import { ProfileComponent } from './profile/profile.component';
import { MainSidebarComponent } from './main-sidebar/main-sidebar.component';
import { MainPageComponent } from './main-page/main-page.component';
import { TimetableComponent } from './timetable/timetable.component';
import { HomeworkComponent } from './homework/homework.component';
import { HomeworksComponent } from './homeworks/homeworks.component';
import { TimetablePartComponent } from './timetable-part/timetable-part.component';
import { AttendanceComponent } from './attendance/attendance.component';
import { AttendanceGroupselectedComponent } from './attendance-groupselected/attendance-groupselected.component';
import { PersonListComponent } from './person-list/person-list.component';
import { AttedanceTableComponent } from './attedance-table/attedance-table.component';
import { AddHomeworkComponent } from './add-homework/add-homework.component';
import { TimetableTeacherComponent } from './timetable-teacher/timetable-teacher.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeworkListTeacherComponent } from './homework-list-teacher/homework-list-teacher.component';
import { CuratorConfirmedComponent } from './curator-confirmed/curator-confirmed.component';
import { CuratorConfirmedListComponent } from './curator-confirmed-list/curator-confirmed-list.component';
import { CuratorStatisticComponent } from './curator-statistic/curator-statistic.component';
import { AUTH_API_URL } from './app-injection-tokens';
import { AuthGuard } from './guards/auth.guard';
import { CuratorstatforPDFComponent } from './curatorstatfor-pdf/curatorstatfor-pdf.component';
import { PortfoliocardComponent } from './portfoliocard/portfoliocard.component';
import { AttedancetableforpdfComponent } from './attedancetableforpdf/attedancetableforpdf.component';
import { ThemesforpdfComponent } from './themesforpdf/themesforpdf.component';
import { AttedanceforpdfComponent } from './attedanceforpdf/attedanceforpdf.component';
import { PrikazCuratorComponent } from './prikaz-curator/prikaz-curator.component';
import { PrikazCuratorPDFComponent } from './prikaz-curator-pdf/prikaz-curator-pdf.component';
import { PrikazCuratorListComponent } from './prikaz-curator-list/prikaz-curator-list.component';
import { ProfileforviewComponent } from './profileforview/profileforview.component';
////import { ConfirmDialogComponent } from './yes-no-modal/confirm-dialog.component';
//import { DialogBodyComponent } from './dialog-body/dialog-body.component';


//const appRoutes: Routes = [
//  {
//    path: 'dashboard', component: mainsidebar,
//    children: [
//      { path: 'home', component: HomeComponentComponent },
//      { path: 'about', component: AboutComponentComponent },
//    ]
//  },
//  { path: 'login', component: LoginComponentComponent },
//  { path: '**', redirectTo: '/login', pathMatch: 'full' }

//];
export function tokenGetter() {
  return localStorage.getItem(ACCESS_TOKEN_KEY);
}
@NgModule({
  declarations: [
    AppComponent,
    ConfirmationDialog,
    AlertDialogComponent,
    MainSidebarComponent,
    ProfileComponent,
    MainPageComponent,
    TimetableComponent,
    HomeworkComponent,
    HomeworksComponent,
    TimetablePartComponent,
    AttendanceComponent,
    AttendanceGroupselectedComponent,
    PersonListComponent,
    AttedanceTableComponent,
    AddHomeworkComponent,
    TimetableTeacherComponent,
    HomeworkListTeacherComponent,
    CuratorConfirmedComponent,
    CuratorConfirmedListComponent,
    CuratorStatisticComponent,
    CuratorstatforPDFComponent,
    PortfoliocardComponent,
    AttedancetableforpdfComponent,
    ThemesforpdfComponent,
    AttedanceforpdfComponent,
    PrikazCuratorComponent,
    PrikazCuratorPDFComponent,
    PrikazCuratorListComponent,
    ProfileforviewComponent
    //ConfirmDialogComponent,
    //DialogBodyComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    [MatDialogModule],
    JwtModule.forRoot({
      config: {
        tokenGetter,
        allowedDomains: environment.tokenWhiteListedDomains
      }
    }),
    FormsModule,
    RouterModule.forRoot([
      //{ path: '', component: HomeComponent, pathMatch: 'full' },
      //{ path: 'counter', component: CounterComponent },
      //{ path: 'fetch-data', component: FetchDataComponent },
      //{ path: 'person', component: PersonComponent },
      {
        path: 'dashboard', component: MainSidebarComponent, 
        children: [
          { path: 'profile/:IdPerson', canActivate: [AuthGuard],  component: ProfileComponent },
          { path: 'profileView/:IdPerson', canActivate: [AuthGuard], component: ProfileforviewComponent },
          { path: 'CuratorStatisticComponent', canActivate: [AuthGuard], component: CuratorStatisticComponent },
          { path: 'curator/:IdPortfolio', canActivate: [AuthGuard], component: CuratorConfirmedComponent },
          { path: 'curatorPortfolioList', canActivate: [AuthGuard],component: CuratorConfirmedListComponent },
          { path: 'mainpage', component: MainPageComponent },
          { path: 'attendance-current/:IdECFLCT/:IdClass/:IdselectedGroup', canActivate: [AuthGuard], component: AttendanceComponent },
          {
            path: 'timetable', canActivate: [AuthGuard], component: TimetableComponent
          },
          {
            path: 'homeworks', canActivate: [AuthGuard], component: HomeworksComponent
          },
          {
            path: 'attedancetable/:IdECFLCT', canActivate: [AuthGuard], component: AttedanceTableComponent
          },
          {
            path: 'attedance', canActivate: [AuthGuard], component: AttendanceComponent,
            children: [
              { path: 'addhomework', component: AddHomeworkComponent }
            ]
          },
          { path: 'homeworks/:IdClass', canActivate: [AuthGuard], component: HomeworkComponent },
          { path: 'personlist', canActivate: [AuthGuard], component: PersonListComponent },
          { path: 'addhomework', canActivate: [AuthGuard], component: AddHomeworkComponent },
          { path: 'checkhomework', canActivate: [AuthGuard], component: HomeworkListTeacherComponent },
          { path: 'timetableTeacher', canActivate: [AuthGuard], component: TimetableTeacherComponent },
          { path: 'CuratorGroup', canActivate: [AuthGuard], component: PortfoliocardComponent},
          {
            path: 'newPrikaz', canActivate: [AuthGuard], component: PrikazCuratorComponent
          },
          {
            path: 'PrikazList', canActivate: [AuthGuard], component: PrikazCuratorListComponent
          },


        ]
      },
      {
        path: 'statisticCurator/:DateStart/:DateEnd', component: CuratorstatforPDFComponent
      },
      {
        path: 'prikazCurator/:IdPrikaza', component: PrikazCuratorPDFComponent
      },
      {
        path: 'statistic/:IdECFLCT/:IdselectedGroup', component: AttedancetableforpdfComponent
      },
      {
        path: 'statisticThemes/:IdECFLCT/:IdselectedGroup', component: ThemesforpdfComponent
      },
      {
        path: 'statisticAttedance/:IdECFLCT/:IdselectedGroup', component: AttedanceforpdfComponent
      },

      //{ path: 'login', component: LoginComponentComponent },
      { path: '**', redirectTo: '/dashboard/mainpage', pathMatch: 'full' }
    ]),
    BrowserAnimationsModule

  ],
  entryComponents: [ConfirmationDialog, AlertDialogComponent],
  providers: [
    MatDialog,
    MatSnackBar,
    {
      provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
      useValue: { appearance: 'fill' }
    },
    {
      provide: AUTH_API_URL,
      useValue: environment.authUrl
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
