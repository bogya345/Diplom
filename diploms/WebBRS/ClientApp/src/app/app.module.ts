import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { ConfirmationDialog } from './dialog-body/confirmation-dialog.component';
import { AlertDialogComponent } from './dialog-body/alert-dialog/alert-dialog.component';
import { VERSION, MatDialogRef,   MatDialog, MatSnackBar,  MAT_DIALOG_DATA, MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material';

import { AppComponent } from './app.component';

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
    CuratorStatisticComponent
    //ConfirmDialogComponent,
    //DialogBodyComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    [MatDialogModule],

    FormsModule,
    RouterModule.forRoot([
      //{ path: '', component: HomeComponent, pathMatch: 'full' },
      //{ path: 'counter', component: CounterComponent },
      //{ path: 'fetch-data', component: FetchDataComponent },
      //{ path: 'person', component: PersonComponent },
      {
        path: 'dashboard', component: MainSidebarComponent,
        children: [
          { path: 'profile/:IdPerson', component: ProfileComponent },
          { path: 'CuratorStatisticComponent', component: CuratorStatisticComponent },
          { path: 'curator/:IdPortfolio', component: CuratorConfirmedComponent },
          { path: 'curatorPortfolioList', component: CuratorConfirmedListComponent },
          { path: 'mainpage', component: MainPageComponent },
          { path: 'attendance-current/:IdECFLCT/:IdClass/:IdselectedGroup', component: AttendanceComponent },
          {
            path: 'timetable', component: TimetableComponent
          },
          {
            path: 'homeworks', component: HomeworksComponent
          },
          {
            path: 'attedancetable/:IdECFLCT', component: AttedanceTableComponent
          },
          {
            path: 'attedance', component: AttendanceComponent,
            children: [
              { path: 'addhomework', component: AddHomeworkComponent }
            ]
          },
          { path: 'homeworks/:IdClass', component: HomeworkComponent },
          { path: 'personlist', component: PersonListComponent },
          { path: 'addhomework', component: AddHomeworkComponent },
          { path: 'checkhomework', component: HomeworkListTeacherComponent },
          { path: 'timetableTeacher', component: TimetableTeacherComponent },



        ]
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
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
