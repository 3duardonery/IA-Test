import { Component, OnInit } from '@angular/core';
import { Device } from 'src/app/models/device';

@Component({
  selector: 'app-device-details',
  templateUrl: './device-details.component.html',
  styleUrls: ['./device-details.component.css']
})
export class DeviceDetailsComponent implements OnInit {

  device: Device;
  constructor() { }

  ngOnInit() {
    this.getDevice();
  }

  getDevice(): void {
    this.device = JSON.parse(localStorage.getItem('device'));
  }

  getPercentage(): number {
    return (((this.device.freeHardDisk/1024) / (this.device.hardDisk/1024)) * 100);
  }

}
