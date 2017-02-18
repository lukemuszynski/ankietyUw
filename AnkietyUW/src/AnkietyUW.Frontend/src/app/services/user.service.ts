import { Injectable } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { environment } from './../../environments/environment';
import {QuestionsForUserViewModel} from './../../models/questionsForUserViewModel';
@Injectable()
export class UserService {

  constructor(private http: Http) { }

  getQuestions(token: string): Observable<QuestionsForUserViewModel> {

    let headers = new Headers({ 'Accept': 'application/json' });

    headers.append('token', token);

    let options = new RequestOptions({ headers: headers });
    console.log(options);
    return this.http.get(environment.serviceUrl + "Answers", options).map(res =>
      res.json()
    );
  }

  registerUser(key: string, email: string): Observable<number> {
    let headers = new Headers({ 'Accept': 'application/json' });
    headers.append('Content-Type','application/json');
    let options = new RequestOptions({ headers: headers });
    
    //headers.append('token', token);
    return this.http.post(environment.serviceUrl + "Register", JSON.stringify({ "key": key, "email": email }),options).map(res => res.json());
  }

  postAnswers(data: any, token: string): Observable<number> {
    
    let headers = new Headers({ 'Accept': 'application/json' });
    headers.append('Content-Type','application/json');
    headers.append('token', token);

    let options = new RequestOptions({ headers: headers });
    console.log(options);

    return this.http.post(environment.serviceUrl + "Answers/Save", JSON.stringify(data),options).map(res => res.json());
  }



}




