import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountPageComponent } from './acc_page/account-page/account-page.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent, data: { title: 'homepage', depth: 1 }},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path:'account-page', component: AccountPageComponent, data: { title: 'accPage', depth: 2 }}
    ]
  },
  {path:'account/login', component: LoginComponent, data: { title: 'loginPage', depth: 2 }},
  {path:'account/register', component: RegisterComponent, data: { title: 'registerPage', depth: 2 }}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
