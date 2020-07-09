import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DevicesComponent } from './pages/devices/devices.component';
import { RegisterComponent } from './pages/register/register.component';
import { DeviceDetailsComponent } from './pages/device-details/device-details.component';

const routes: Routes = [
  {
    component: DevicesComponent,
    path: ''
  },
  {
    component: RegisterComponent,
    path: 'register'
  },
  {
    component: DeviceDetailsComponent,
    path: 'details/:id'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
