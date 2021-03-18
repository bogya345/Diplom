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

/// semka's
import { BrsHomeComponent } from './brs-home/brs-home.component';

const brs_routes: Routes = [
  { path: 'home', component: BrsHomeComponent},
];
///

const routes: Routes = [

  { path: '', pathMatch: 'full'},
  { path: 'login', component: LoginComponent},

  // bogya
  { path: 'hod', children: hod_routes },

  // semka
  { path: 'brs', children: brs_routes },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
