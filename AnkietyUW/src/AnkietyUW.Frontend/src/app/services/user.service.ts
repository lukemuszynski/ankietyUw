import { Injectable } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { environment } from './../../environments/environment';
@Injectable()
export class UserService {

  constructor(private http: Http) { }

  getQuestions(token: string): Observable<number[][]> {

    let headers = new Headers({ 'Accept': 'application/json' });

    headers.append('token', token);

    let options = new RequestOptions({ headers: headers });
    console.log(options);
    return this.http.get(environment.serviceUrl + "Answers", options).map(res =>
      res.json()
    );
  }

  registerUser(key: string, email: string): Observable<number> {
    
    return this.http.post(environment.serviceUrl + "Register", JSON.stringify({ "key": key, "email": email })).map(res => res.json());
  }

  postAnswers(data: any, token: string): Observable<number> {
    
   let headers = new Headers({ 'Accept': 'application/json' });

    headers.append('token', token);

    let options = new RequestOptions({ headers: headers });
    console.log(options);

    return this.http.post(environment.serviceUrl + "Answer", JSON.stringify(data)).map(res => res.json());
  }



}




