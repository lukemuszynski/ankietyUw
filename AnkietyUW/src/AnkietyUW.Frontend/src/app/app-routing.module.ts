import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserAnswerComponent } from './user-answer/user-answer.component';
import { RegisterUserComponent } from './register-user/register-user.component';
import { ActionCompletedUserComponent } from './action-completed-user/action-completed-user.component';

const routes: Routes = [
  {
    path: '',
    children: []
  },
  { path: 'user-answer/:token', component: UserAnswerComponent },
  { path: 'user-register/:email', component: RegisterUserComponent },
  { path: 'user-action-completed', component: ActionCompletedUserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }
