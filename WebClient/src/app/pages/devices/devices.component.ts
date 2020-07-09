import { Component, OnInit } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from 'src/environments/environment';
import { DeviceService } from './device.service';
import { Device } from 'src/app/models/device';
import { Router } from '@angular/router';

const connection = new signalR.HubConnectionBuilder()
  .withUrl(`${environment.url}/machine`, {
    transport: signalR.HttpTransportType.LongPolling
  })
  .build();

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit {

  devices: Device[] = [];
  selectedDevice: Device;

  constructor(private deviceService: DeviceService,
    private router: Router) {
    this.initConnection();
  }

  ngOnInit() {
    this.getDevices();
    connection.on("ForceUpdate", (update: boolean) => {
      if (update)
        this.getDevices();
    });
  }

  initConnection(): void {
    connection.start()
      .then(() => console.log('Signal Conectado'))
      .catch(err => {
        console.log(err);
      });
  }

  getDevices(): void {
    this.deviceService.getDevices()
      .subscribe(
        (res) => {
          this.devices = res;
        },
        (err) => {
          console.log(err);
        }
      );
  }

  goToDetails(id: string):void {


    this.selectedDevice = this.devices.find(x => x.connectionId === id);

    localStorage.setItem('device', JSON.stringify(this.selectedDevice));
    this.router.navigate(['details', id]);
  }

}
