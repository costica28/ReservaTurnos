import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { AuthService } from '../auth/auth.service';
import { Token } from '../../DTO/token.dto';

@Injectable({
  providedIn: 'root'
})
export class CommerceService {

  constructor(private _http: HttpClient, private _authService:AuthService) { }

  getAll(){
    let tokenLocalStorage = this._authService.getToken();
    let token = "";
    if(tokenLocalStorage != null){
      const tokenEntity:Token = JSON.parse(tokenLocalStorage);
      token = tokenEntity.access_token
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization' : 'Bearer ' + token,
        'Content-Type': 'application/json',
      })
    };
    return this._http.get<any>(`${environment.apiUrl}Commerce/GetAll`,httpOptions);
  }
}
