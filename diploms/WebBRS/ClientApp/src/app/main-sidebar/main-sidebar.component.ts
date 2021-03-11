import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-sidebar',
  templateUrl: './main-sidebar.component.html',
  styleUrls: ['./main-sidebar.component.css']
})
export class MainSidebarComponent implements OnInit {

  constructor(public router: Router) { }

  ngOnInit(): void {
  }

  redirectToHome() {
    this.router.navigateByUrl('dashboard/mainpage');
  }
  redirectToProfile() {
    this.router.navigateByUrl('dashboard/profile');
  }
}
