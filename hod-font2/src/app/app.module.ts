import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

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

@NgModule({
  declarations: [
    AppComponent,
    HodHomeComponent,
    LoginComponent,
    HodDepsComponent,
    HodPromotionComponent,
    HodAcplanComponent,
    HodDepComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,

    HttpClientModule,

    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
