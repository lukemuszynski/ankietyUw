import { Injectable } from '@angular/core';

import { Observable } from "rxjs/Observable";
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { environment } from './../../environments/environment';
import { AllTestsViewModel } from './../../models/allTestsViewModel';
@Injectable()
export class AdminService {

  constructor(private http: Http) { }

  token: string = "";

  getAllTests(): Observable<AllTestsViewModel[]> {

    let headers = new Headers({ 'Accept': 'application/json' });

    headers.append('token', this.token);

    let options = new RequestOptions({ headers: headers });
    console.log(options);
    return this.http.get(environment.serviceUrl + "Tests/Show", options).map(res =>
      res.json()
    );
  }

}
