import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact';

@Injectable({
  providedIn: 'root',
})
export class ContactService {

  private apiUrl:string ='https://localhost:7289/api/Contacts';

  constructor(private httpCilent: HttpClient){}

   public getContacts(): Observable<Contact[]>{
       return this.httpCilent.get<Contact[]>(this.apiUrl);
    }

    public getContactById(id: number): Observable<Contact> {
    return this.httpCilent.get<Contact>(`${this.apiUrl}/${id}`);
  }

  public  addContact(contact: Contact): Observable<Contact> {
    return this.httpCilent.post<Contact>(this.apiUrl, contact);
  }

  public updateContact(contact: Contact): Observable<any> {
    return this.httpCilent.put(`${this.apiUrl}/${contact.id}`, contact);
  }

  public deleteContact(id: number): Observable<any> {
    return this.httpCilent.delete(`${this.apiUrl}/${id}`);
  }

  
  
  
}


