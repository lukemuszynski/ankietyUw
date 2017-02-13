import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserAnswerComponent } from './user-answer/user-answer.component';
import { QuestionsUserComponent } from './questions-user/questions-user.component';
import { MaterialModule } from '@angular/material';
import { RegisterUserComponent } from './register-user/register-user.component';
@NgModule({
  declarations: [
    AppComponent,
    UserAnswerComponent,
    QuestionsUserComponent,
    RegisterUserComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,
    MaterialModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
