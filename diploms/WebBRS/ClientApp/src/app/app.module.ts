import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { MatDatepickerModule } from '@angular/material/datepicker';

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
//import { YesNoModalComponent } from './yes-no-modal/yes-no-modal.component';


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
    HomeworkListTeacherComponent
    //YesNoModalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
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
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
