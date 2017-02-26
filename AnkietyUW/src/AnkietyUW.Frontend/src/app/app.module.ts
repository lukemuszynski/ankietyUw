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
import { UserService } from './services/user.service';
import { AdminService } from './services/admin.service';
import { ActionCompletedUserComponent } from './action-completed-user/action-completed-user.component';
import { MdSnackBarModule, MdSnackBar, MdInputModule } from '@angular/material';
import { AdminTestListComponent } from './admin-test-list/admin-test-list.component';
import { AdminLoginComponent } from './admin-login/admin-login.component';
@NgModule({
  declarations: [
    AppComponent,
    UserAnswerComponent,
    QuestionsUserComponent,
    RegisterUserComponent,
    ActionCompletedUserComponent,
    AdminTestListComponent,
    AdminLoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,
    MaterialModule.forRoot(),
    MdSnackBarModule,
    MdInputModule
  ],
  providers: [UserService, AdminService,MdSnackBar],
  bootstrap: [AppComponent]
})
export class AppModule { }
