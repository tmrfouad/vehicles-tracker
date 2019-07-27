import { Component, OnInit } from "@angular/core";
import { CustomerService } from "../services/customer.service";
import { Customer } from "../models/customer";
import { Vehicle } from "../models/vehicle";
import { VehicleService } from "../services/vehicle.service";
import { SignalRService } from "../services/signal-r.service";

@Component({
  selector: "app-vehicle-tracker",
  templateUrl: "./vehicle-tracker.component.html",
  styleUrls: ["./vehicle-tracker.component.css"]
})
export class VehicleTrackerComponent implements OnInit {
  public customers: Customer[] = [];
  public vehicles: Vehicle[] = [];
  public filteredVehicles: Vehicle[] = [];
  public customerFilter: number;
  public statusFilter: boolean;

  constructor(
    private customerService: CustomerService,
    private vehicleService: VehicleService,
    public signalRService: SignalRService
  ) {}

  ngOnInit(): void {
    this.customerService
      .getCustomers()
      .subscribe(customers => (this.customers = customers));
    this.vehicleService
      .getVehicles()
      .subscribe(vehicles => {
        this.vehicles = vehicles
        this.filterVehicles();
      });
    this.signalRService.startConnection();
    this.signalRService.addTransferVehiclesDataListener(
      this.mapVehiclesStatus.bind(this)
    );
    this.signalRService
      .startHttpRequest()
      .subscribe((res: { message: string }) => {
        console.log(res.message);
      });
  }

  private mapVehiclesStatus() {
    if (!this.signalRService.data || !this.vehicles) return;
    this.vehicles = this.vehicles.map(v => ({
      ...v,
      on: this.signalRService.data.find(d => d.vehicleId === v.vehicleId).on
    }));
    this.filterVehicles();
  }

  filterVehicles() {
    this.filteredVehicles = this.vehicles.filter(
      v =>
        (!this.customerFilter || v.customerId == this.customerFilter) &&
        (!this.statusFilter || v.on == this.statusFilter)
    );
  }
}
