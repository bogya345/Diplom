import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

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
    AttedanceTableComponent
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
          { path: 'profile', component: ProfileComponent },
          { path: 'mainpage', component: MainPageComponent },
          { path: 'attendance-current', component: AttendanceComponent },
          {
            path: 'timetable', component: TimetableComponent,
            children: [
              { path: 'timetable-part', component: TimetablePartComponent }
            ]
          },
          {
            path: 'homeworks', component: HomeworksComponent
          },
          {
            path: 'attedancetable', component: AttedanceTableComponent
          },
          { path: 'homeworks/183', component: HomeworkComponent },
          { path: 'personlist', component: PersonListComponent }

        ]
      },
      //{ path: 'login', component: LoginComponentComponent },
      { path: '**', redirectTo: '/dashboard/mainpage', pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
