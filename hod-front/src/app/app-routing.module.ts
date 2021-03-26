import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
// import { homedir } from 'node:os';

import { LoginComponent } from './login/login.component';

/// bogya's
import { HodHomeComponent } from './hod-home/hod-home.component';

const hod_routes: Routes = [
  { path: 'home', component: HodHomeComponent},
];
///


const routes: Routes = [

  { path: '', pathMatch: 'full', redirectTo: 'home'},
  { path: 'login', component: LoginComponent},

  // bogya
  { path: 'hod', children: hod_routes },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
