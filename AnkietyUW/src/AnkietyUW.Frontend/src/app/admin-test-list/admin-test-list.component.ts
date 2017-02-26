import { Component, OnInit } from '@angular/core';
import { AdminService } from './../services/admin.service';
import { AllTestsViewModel } from './../../models/allTestsViewModel';

@Component({
  selector: 'app-admin-test-list',
  templateUrl: './admin-test-list.component.html',
  styleUrls: ['./admin-test-list.component.scss']
})
export class AdminTestListComponent implements OnInit {

  constructor(private adminService: AdminService) { }
  allTests: AllTestsViewModel[];

  ngOnInit() {

      this.adminService.getAllTests().subscribe(res => this.allTests = res);

  }

}
