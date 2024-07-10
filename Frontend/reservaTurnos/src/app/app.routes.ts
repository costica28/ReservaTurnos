import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './features/components/login/login.component';
import { HomeComponent } from './features/components/home/home.component';
import { NgModule } from '@angular/core';
import { AuthGuard } from './features/components/authGuard/authguard';

const routes: Routes = [
  { path: "login", component: LoginComponent},
  { path: "home", component: HomeComponent, canActivate: [AuthGuard]},
  { path: "", redirectTo:"login", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
