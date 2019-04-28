import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WeatherData } from '../models/weather-data';
import { ForecastService } from '../services/forecast.service';

@Component({
  selector: 'forecast-data',
  templateUrl: './forecast.component.html'
})
export class ForecastComponent {

  public forecasts: WeatherData;

  public cityName: string;

  constructor(private forecastService: ForecastService) {

  }

  onLoadForecastClick() {
    console.log(this.cityName);
    if (typeof this.cityName !== 'undefined' && this.cityName) {
      this.forecastService.getForecast(this.cityName).then((response) => {
        this.forecasts = response;
      });
    }
  }
}
