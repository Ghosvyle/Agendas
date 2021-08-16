import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactoService {
  private myappurl = 'https://localhost:44327/';
  private myapiurl = 'api/contacto/';

  constructor(private http: HttpClient) {}
  getListContactos(): Observable<any>{
    return this.http.get(this.myappurl + this.myapiurl);
  }
  deletecontacto(id: number): Observable<any>{
    return this.http.delete(this.myappurl + this.myapiurl + id);
  }

  savecontacto(contacto: any): Observable<any>{
    return this.http.post(this.myappurl + this.myapiurl, contacto);
  }
  updatecontacto(id: number, contacto: any): Observable<any>{
    return this.http.put(this.myappurl + this.myapiurl + id, contacto);
  }
}
