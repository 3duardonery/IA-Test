import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import * as signalR from '@microsoft/signalr';
import { Device } from 'src/app/models/device';

const connection = new signalR.HubConnectionBuilder()
  .withUrl(`${environment.url}/machine`, {
    transport: signalR.HttpTransportType.LongPolling
  })
  .build();

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  device: Device = {
    antivirusName: 'Avira',
    connectionId: connection.connectionId,
    hasAntivirus: true,
    name: 'Teste',
    ipAddress: '100.10.1.12',
    osVersion: '10',
    freeHardDisk: 307200,
    hardDisk: 512000,
    disk: null
  };

  constructor() { }

  ngOnInit() {
    this.initConnection();


  }

  initConnection(): void {

    connection.start()
      .then(() => {
        this.device.connectionId = connection.connectionId;
        var informationJson = JSON.stringify(this.device);
        connection.invoke("RegisterDeviceInformation", informationJson);
      })
      .catch(err => {
        console.log(err);
      });
  }



}
