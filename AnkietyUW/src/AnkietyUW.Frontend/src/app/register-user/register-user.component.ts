import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { UserService } from './../services/user.service';
import { Router } from '@angular/router';
import { MdSnackBar, MdSnackBarConfig, MdInputDirective } from '@angular/material';
@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss']
})
export class RegisterUserComponent implements OnInit {

  constructor(private router: Router, private route: ActivatedRoute, private userService: UserService, public snackBar: MdSnackBar) { }
  private sub: any;
  private email: string;
  warning: boolean;
  key: string = "";

  @ViewChild("registerForm") form: FormData;
  @ViewChild("key0") key0: MdInputDirective;
  @ViewChild("key1") key1: MdInputDirective;
  @ViewChild("key2") key2: MdInputDirective;
  @ViewChild("key3") key3: MdInputDirective;
  @ViewChild("key4") key4: MdInputDirective;

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.email = params['email'];

      if (!this.email) {
        this.warning = true;
        return;
      }

    });

  }

  registerUser(k0, k1, k2, k3, k4) {
    
    // this.router.navigate(["user-action-completed"]);

    if (!k0 || !k1 || !k2 || !k3 || !k4 || k0 == "" || k1 == "" || k2 == "" || k3 == "" || k4 == "")
    { this.openSnackBar(); return; }

    this.key = k0 + k1 + k2 + k3 + k4;
    this.key = this.key.toLocaleUpperCase();
    console.info(this.key);

   

    this.userService.registerUser(this.key, this.email).subscribe(res => {
      console.log(res);
      if (res === 1)
        this.router.navigate(["user-action-completed"]);
      else {
        this.openSnackBar();
      }
    }).closed = true;

  }

  openSnackBar() {
    let config: MdSnackBarConfig = new MdSnackBarConfig();
    config.duration = 2000;
    config.politeness = "assertive";

    this.snackBar.open("Użytkownik o takim kodzie nie istnieje. Sprawdź poprawność danych.", "", config)
  }

}
