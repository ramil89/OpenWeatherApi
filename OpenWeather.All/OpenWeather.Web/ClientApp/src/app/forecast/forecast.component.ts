import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WeatherData } from '../models/weather-data';
import { ForecastService } from '../services/forecast.service';
import { timer, Subject, Subscription, Observable } from 'rxjs';

@Component({
  selector: 'forecast-data',
  templateUrl: './forecast.component.html'
})
export class ForecastComponent {

  public forecasts: WeatherData;

  public cityTxt: string;

  public city: string;

  public syncDate: Date;

  private timerSubscription: Subscription;

  constructor(private forecastService: ForecastService) {

  }

  onLoadForecastClick() {
    this.city = this.cityTxt;

    if (this.city) {
      if (this.timerSubscription)
        this.timerSubscription.unsubscribe();

      this.timerSubscription = timer(0, 30000).subscribe(val => {
        console.log(val, '-');
        this.forecastService.getForecast(this.city).then((response) => {
          this.forecasts = response;
          this.syncDate = new Date();
        })
          .catch((response) => {
            this.forecasts = [];
            console.log(response);
          });
      });
    }
  }
}
