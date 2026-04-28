import { Injectable } from '@angular/core';
import { Contact } from './contact';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private contacts : Contact[] = [
    {id:501, name:"Vinay", email:"vinay@gmail.com", phone:'9966332255'},
    {id:502, name:"Vinaykumar", email:"vinaykumar@gmail.com", phone:'9966335588'},
    {id:503, name:"Vini", email:"vini@gmail.com", phone:'9966337799'},
    {id:504, name:"Ramu", email:"ramu@gmail.com", phone:'996633224411'},
    {id:505, name:"Ravi", email:"ravi@gmail.com", phone:'9966332233'},
  ];

  public getContacts(): Contact[] {
    return this.contacts;
  }

  public addContact(contact: Contact):void{
    this.contacts.push(contact);
  }

  public getContactById(id: number): Contact | undefined {
    return this.contacts.find(c=>c.id===id);
  }
  
}
