import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Device } from 'src/app/models/device';
import { log } from 'console';

@Component({
  selector: 'app-devices-list',
  templateUrl: './devices-list.component.html',
  styleUrls: ['./devices-list.component.css']
})
export class DevicesListComponent implements OnInit {

  @Input() devices: Device[] = [];
  listOfDevices: Device[];

  constructor() {
    this.listOfDevices = this.devices;
    console.log(this.listOfDevices);
    console.log('====================================');
    console.log(this.devices);

   }

  ngOnInit() {

  }

}
