import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpGenericService {

  constructor(private http:HttpClient) { }

  public post<T>(url:string, body:T):Observable<any>{
      return this.http.post(url,body)
  }
}
