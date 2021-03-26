import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
// import { homedir } from 'node:os';

import { LoginComponent } from './login/login.component';

/// bogya's
import { HodHomeComponent } from './hod-home/hod-home.component';
import { HodDepsComponent } from './hod-deps/hod-deps.component';
import { HodDepComponent } from './hod-dep/hod-dep.component';
import { HodAcplanComponent } from './hod-acplan/hod-acplan.component';

const hod_routes: Routes = [

  // главная страница (сведения о кафедре пользователя)
  { path: 'home', component: HodHomeComponent},

  // список кафедр
  { path: 'deps', component: HodDepsComponent},

  // инфомация о выбранной кафедре (ее направления)
  { path: 'dep/:dep_id', component: HodDepComponent},

  // учебный план группы (направления)
  { path: 'dep/:dep_id/:dir_id/:group_id', component: HodAcplanComponent},

];
///

const routes: Routes = [

  { path: '', pathMatch: 'full', redirectTo: 'hod/home'},
  { path: 'login', component: LoginComponent},

  /// bogya
  { path: 'hod', children: hod_routes },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
