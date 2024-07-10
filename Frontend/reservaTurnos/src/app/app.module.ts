import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './features/components/login/login.component';
import { HomeComponent } from './features/components/home/home.component';
import { AppRoutingModule } from './app.routes';
import { AuthService } from './features/services/auth/auth.service';
import { AuthGuard } from './features/components/authGuard/authguard';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { StatusEnumPipe } from './shared/pipes/statusEnum/status-enum.pipe';

@NgModule({
    declarations: [
      AppComponent,
      LoginComponent,
      HomeComponent,
      StatusEnumPipe
    ],
    imports:[
      BrowserModule,
      FormsModule,
      HttpClientModule,
      BrowserAnimationsModule,
      ReactiveFormsModule,
      AppRoutingModule
    ],
    exports: [StatusEnumPipe],
    providers: [AuthService, AuthGuard, provideAnimationsAsync()],
    bootstrap: [AppComponent]
})

export class AppModule {}
