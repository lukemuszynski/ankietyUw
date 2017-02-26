import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserAnswerComponent } from './user-answer/user-answer.component';
import { RegisterUserComponent } from './register-user/register-user.component';
import { ActionCompletedUserComponent } from './action-completed-user/action-completed-user.component';
import { AdminTestListComponent } from './admin-test-list/admin-test-list.component';

const routes: Routes = [
  {
    path: '',
    children: []
  },
  { path: 'user-answer/:token', component: UserAnswerComponent },
  { path: 'user-register/:email', component: RegisterUserComponent },
  { path: 'user-action-completed', component: ActionCompletedUserComponent },
  { path: 'admin-test-list', component: AdminTestListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }
