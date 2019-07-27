import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getCustomers() {
    return this.http.get<Customer[]>(`${this.baseUrl}api/customers`);
  }
}
