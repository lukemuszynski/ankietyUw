import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss']
})
export class RegisterUserComponent implements OnInit {

  constructor(private route: ActivatedRoute, private http: Http) { }
  private sub: any;
  private email: string;
  warning: boolean;

  key: string = "     ";

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.email = params['email'];

      if (!this.email) {
        this.warning = true;
        return;
      }
      console.info("email:");
      console.log(this.email);

    });


  }

}
