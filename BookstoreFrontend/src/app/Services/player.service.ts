import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  APIurl = 'http://localhost:50536/api/Player';
constructor(private http: HttpClient) { }


  getPlayers() : Observable<any[]>
  {
    return this.http.get<any[]>(this.APIurl + "/GetPlayers");
  }
}
