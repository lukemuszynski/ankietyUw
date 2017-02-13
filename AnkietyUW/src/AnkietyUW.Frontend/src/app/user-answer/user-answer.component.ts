import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { JwtHelper } from 'angular2-jwt';
import { QuestionsUserComponent } from './../questions-user/questions-user.component';
import { Observable } from "rxjs/Observable";
import { Http, Response, Headers, RequestOptions } from '@angular/http';

@Component({
  selector: 'app-user-answer',
  templateUrl: './user-answer.component.html',
  styleUrls: ['./user-answer.component.scss']
})
export class UserAnswerComponent implements OnInit, OnDestroy {

  constructor(private route: ActivatedRoute, private http: Http) { }

  private sub: any;
  decodedToken: any;
  warning: boolean;
  token: string;

  questionsNumbers: any;

  ngOnInit() {

    this.sub = this.route.params.subscribe(params => {
      this.token = params['token'];
      if (!this.token) {
        this.warning = true;
        return;
      }

      let helper: JwtHelper = new JwtHelper();
      this.decodedToken = helper.decodeToken(this.token);


      console.log(this.decodedToken);

      this.getQuestions().subscribe(res => {
        console.log(res);
        this.questionsNumbers = res;
      })

    });

  }

  getQuestions(): Observable<number[][]> {

    let headers = new Headers({ 'Accept': 'application/json' });

    headers.append('token', this.token);

    let options = new RequestOptions({ headers: headers });
    console.log(options);
    return this.http.get("http://localhost:53980/Answers", options).map(res =>
      res.json()
    );


  }


  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
