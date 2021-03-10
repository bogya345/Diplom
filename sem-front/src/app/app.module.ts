import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PersonComponent } from './person/person.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponentComponent } from './login-component/login-component.component';
import { HeaderComponentComponent } from './header-component/header-component.component';
import { HomeComponentComponent } from './home-component/home-component.component';
import { AboutComponentComponent } from './about-component/about-component.component';
import { ProfileComponent } from './profile/profile.component';

const appRoutes: Routes = [
  {
    path: 'dashboard', component: HeaderComponentComponent,
    children: [
      { path: 'home', component: HomeComponentComponent },
      { path: 'about', component: AboutComponentComponent },
    ]
  },
  { path: 'login', component: LoginComponentComponent },
  { path: '**', redirectTo: '/login', pathMatch: 'full' }

];

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PersonComponent,

    LoginComponentComponent,
    HeaderComponentComponent,
    HomeComponentComponent,
    AboutComponentComponent,
    ProfileComponent
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
      { path: 'dashboard', component: HeaderComponentComponent,
        children: [
          { path: 'home', component: HomeComponentComponent },
          { path: 'about', component: AboutComponentComponent },
          { path: 'profile', component: ProfileComponent },
        ]
      },
      { path: 'login', component: LoginComponentComponent },
      { path: '**', redirectTo: '/login', pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
