import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vehicle } from '../models/vehicle';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getVehicles() {
    return this.http.get<Vehicle[]>(`${this.baseUrl}api/vehicles`);
  }
}
