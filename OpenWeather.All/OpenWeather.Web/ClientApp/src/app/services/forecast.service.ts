import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { WeatherData } from '../models/weather-data';
import { environment } from '../../environments/environment';

@Injectable()
export class ForecastService {
  constructor(private http: HttpClient) {

  }

  getForecast(cityName: string) {
    var promise = new Promise<WeatherData>((resolve, reject) => {

      return this.http.get<WeatherData[]>(environment.ApiUrl + "/api/weather/forecast?q=" + cityName)
        .toPromise().then((response) => {
          console.log(response);
          resolve(response);
        }, (error) => {
          console.log(error);
          reject(error);
        });
    });

    return promise;
  }

}
