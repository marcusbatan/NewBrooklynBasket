import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { statlineModel } from '../Models/statlineModel';

@Injectable({
  providedIn: 'root'
})

export class StatlineService {

  APIurl = 'http://localhost:50536/api/Stats';

  constructor(private http: HttpClient) { }

  registerStatline(statlineMdl: statlineModel) : Observable<any>
  {
      return this.http.post<any>(this.APIurl + "/RegisterStatline", statlineMdl);
  }
}
