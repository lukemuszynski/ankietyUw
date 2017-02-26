import { Component, OnInit } from '@angular/core';
import { AdminService } from './../services/admin.service';

import { ActivatedRoute } from '@angular/router';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Router } from '@angular/router';
import { MdSnackBar, MdSnackBarConfig, MdInputDirective } from '@angular/material';

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.scss']
})
export class AdminLoginComponent implements OnInit {

  constructor(private adminService: AdminService, private router: Router, private route: ActivatedRoute, private snackBar: MdSnackBar) { }

  ngOnInit() {

  }

  loginAdmin(login: string, password: string) {
    this.router.navigate(["admin-test-list"]);
  }

}
