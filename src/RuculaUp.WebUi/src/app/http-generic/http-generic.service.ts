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
  public put<T>(url:string, body:T):Observable<any>{
    return this.http.put(url,body)
  }
  public delete(url:string):Observable<any>{
    return this.http.delete(url)
  }
}
