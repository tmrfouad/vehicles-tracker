import { Injectable, Inject } from "@angular/core";
import * as signalR from "@aspnet/signalr";
import { VehicleStatus } from "../models/Vehicle-status";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class SignalRService {
  public data: VehicleStatus[];
  private hubConnection: signalR.HubConnection;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${this.baseUrl}vehicles`)
      .build();

    this.hubConnection
      .start()
      .then(() => console.log("Connection Started"))
      .catch(err => console.log(`Error while starting connection: ${err}`));
  };

  public addTransferVehiclesDataListener = callback =>
    this.hubConnection.on("transfervehiclesdata", data => {
      this.data = data;
      callback();
    });

  public startHttpRequest = () =>
    this.http.get(`${this.baseUrl}api/tracker`);
}
