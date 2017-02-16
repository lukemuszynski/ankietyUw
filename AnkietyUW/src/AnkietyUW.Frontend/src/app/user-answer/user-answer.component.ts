import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { JwtHelper } from 'angular2-jwt';
import { QuestionsUserComponent } from './../questions-user/questions-user.component';
import { Observable } from "rxjs/Observable";
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { UserService } from './../services/user.service';
@Component({
  selector: 'app-user-answer',
  templateUrl: './user-answer.component.html',
  styleUrls: ['./user-answer.component.scss']
})
export class UserAnswerComponent implements OnInit, OnDestroy {

  constructor(private route: ActivatedRoute, private http: Http, private userService: UserService) { }

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

      this.questionsNumbers = [[1,2,5,6,16,19,22,24,25],[9,13,19],[4,13,19]];
      // this.userService.getQuestions(this.token).subscribe(res => {
      //   console.log(res);
      //   this.questionsNumbers = res;
      // })

    });

  }



  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
