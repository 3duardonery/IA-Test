import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DevicesComponent } from './pages/devices/devices.component';
import { DevicesListComponent } from './components/devices-list/devices-list.component';
import { RegisterComponent } from './pages/register/register.component';
import { DeviceDetailsComponent } from './pages/device-details/device-details.component';

@NgModule({
  declarations: [
    AppComponent,
    DevicesComponent,
    DevicesListComponent,
    RegisterComponent,
    DeviceDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
