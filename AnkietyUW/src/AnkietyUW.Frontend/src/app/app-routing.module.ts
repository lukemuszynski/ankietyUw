import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserAnswerComponent } from './user-answer/user-answer.component';
import { RegisterUserComponent } from './register-user/register-user.component';
const routes: Routes = [
  {
    path: '',
    children: []
  },
  { path: 'user-answer/:token', component: UserAnswerComponent },
  { path: 'user-register/:email', component: RegisterUserComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }
