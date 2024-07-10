import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { Token } from '../../DTO/token.dto';
import { environment } from '../../../../environments/environment';
import { GenerateShiftsRequest } from '../../DTO/generateShiftsRequest.dto';

@Injectable({
  providedIn: 'root'
})
export class ShiftService {

  constructor(private _http: HttpClient, private _authService:AuthService) { }

  GenerateShift(generateShiftsRequest:GenerateShiftsRequest){
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
    return this._http.post<any>(`${environment.apiUrl}Shifts/GenerateShifts`, generateShiftsRequest,httpOptions);
  }
}
