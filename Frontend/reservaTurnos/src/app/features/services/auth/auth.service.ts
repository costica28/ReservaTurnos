import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Token } from '../../DTO/token.dto';
import { environment } from '../../../../environments/environment';
import { AuthRequest } from '../../DTO/authRequest.dto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _http: HttpClient) { }
  private readonly TOKEN_KEY = 'authToken';

  login(authRequest:AuthRequest):Observable<any>{
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this._http.post<any>(`${environment.apiUrl}Auth/Login`, authRequest, httpOptions);
  }
  getToken():string | null{
    return localStorage.getItem(this.TOKEN_KEY);
  }

  setToken(token: string): void {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  clearToken(): void {
    localStorage.removeItem(this.TOKEN_KEY);
  }

  isLoggedIn(): boolean {
    return this.getToken() !== null;
  }
}
