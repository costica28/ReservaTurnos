import { Commerce } from './../../../../models/commerce.model';
import { Component, OnInit } from '@angular/core';
import { CommerceService } from '../../services/commerce/commerce.service';
import { ServiceService } from '../../services/service/service.service';
import { Service } from '../../../../models/service.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GenerateShiftsRequest } from '../../DTO/generateShiftsRequest.dto';
import { DatePipe } from '@angular/common';
import { Shift } from '../../../../models/shift.model';
import { ShiftService } from '../../services/shift/shift.service';
import { AuthService } from '../../services/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  providers:[DatePipe]
})
export class HomeComponent implements OnInit{

  FormGenerateShift: FormGroup;
  commerces: Commerce[] = [];
  services: Service[] = [];
  servicesTemporal: Service[] = [];
  shifts: Shift[] = [];

  constructor(private _commerceService: CommerceService, private _serviceService: ServiceService,
    private _formBuilder: FormBuilder, private _datePipe: DatePipe, private _shiftsService: ShiftService,
    private _authService: AuthService, private _router:Router){
    this.FormGenerateShift = this._formBuilder.group({
      commerce: ['', Validators.required],
      service: ['', Validators.required],
      dateInitial: ['', Validators.required],
      dateFinal: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.getAllCommerce();
    this.getAllService();
  }

  getAllCommerce(){
    this._commerceService.getAll().subscribe(response => {
      this.commerces = response.data;
    });
  }

  getAllService(){
    this._serviceService.getAll().subscribe(response=> {
      this.services = response.data;
    });
  }

  commerceSelected(event: Event): void {
    var idCommerceSelected = (event.target as HTMLSelectElement).value;
    this.servicesTemporal = this.services.filter(s=> s.id_comercio ==  Number(idCommerceSelected));
  }

  generateShift(){
    const formData: GenerateShiftsRequest = {
      IdServicio: Number(this.FormGenerateShift.value.service),
      FechaInicio: this.transformDate(this.FormGenerateShift.value.dateInitial),
      FechaFin: this.transformDate(this.FormGenerateShift.value.dateFinal)
    }

    this._shiftsService.GenerateShift(formData).subscribe((response:any)=>{
      this.shifts = response.data;
      this.FormGenerateShift.reset();
    },error=> alert(error.error.Message))
  }

  transformDate(date:any): string {
    // Transformar la fecha usando DatePipe
    const fechaTransformada = this._datePipe.transform(date, 'dd/MM/yyyy');
    return fechaTransformada || '';
  }

  logout(){
    this._authService.clearToken();
    if(!this._authService.isLoggedIn())
    {
      this._router.navigate(["/login"]);
    }
  }

}
