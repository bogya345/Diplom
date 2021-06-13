import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

// import { homedir } from 'node:os';

import { LoginComponent } from './login/login.component';

/// bogya's
import { HodHomeComponent } from './hod-home/hod-home.component';
import { HodDepsComponent } from './hod-deps/hod-deps.component';
import { HodDepComponent } from './hod-dep/hod-dep.component';
import { HodAcplanComponent } from './hod-acplan/hod-acplan.component';
import { HodPromotionComponent } from './hod-promotion/hod-promotion.component';
import { HodShowAcPlanComponent } from './hod-show-ac-plan/hod-show-ac-plan.component';
import { HodFgosSettingComponent } from './hod-fgos-setting/hod-fgos-setting.component';

// test
import { SnackBarComponent } from './snack-bar/snack-bar.component';
import { HodMapSubDepComponent } from './hod-map-sub-dep/hod-map-sub-dep.component';

const hod_mapper: Routes = [
  
  // маппинг дисциплины с кафедрой
  { path: 'subdep', component: HodMapSubDepComponent },
  
];

const hod_routes: Routes = [

  // главная страница (сведения о кафедре пользователя)
  { path: 'home', component: HodHomeComponent },

  // список кафедр
  // { path: 'deps', component: HodDepsComponent, data: { 'msg': 'message' } },
  { path: 'deps', component: HodDepsComponent },

  // инфомация о выбранной кафедре (ее направления)
  { path: 'dep/own', component: HodDepComponent },

  // инфомация о выбранной кафедре (ее направления)
  { path: 'deps/promotion', component: HodPromotionComponent },

  // учебный план группы (направления)
  { path: 'dep/:dep_id/:dir_id/:group_id', component: HodAcplanComponent },

  // просмотр учебного плана направления
  { path: 'acplan/:acPl_id', component: HodShowAcPlanComponent },

  // просмотр учебного плана направления
  { path: 'fgos/requirs', component: HodFgosSettingComponent },

  // просмотр учебного плана направления
  { path: 'mapper', children: hod_mapper },

];
///

const routes: Routes = [

  { path: '', pathMatch: 'full', redirectTo: 'hod/home' },
  { path: 'login', component: LoginComponent },

  /// bogya
  { path: 'hod', children: hod_routes },

  { path: 'test', component: SnackBarComponent }

];

@NgModule({
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
