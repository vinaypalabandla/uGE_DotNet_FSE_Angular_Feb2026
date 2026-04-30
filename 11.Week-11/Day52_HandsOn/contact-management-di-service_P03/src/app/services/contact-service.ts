import { Injectable } from '@angular/core';
import { Contact } from '../models/contact';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
    private contacts: Contact[] = [
    { id: 1, name: 'Vinay', email: 'vinay@gmail.com', phone: '9999999999' },
    { id: 2, name: 'Rahul', email: 'rahul@gmail.com', phone: '8888888888' }
  ];

  // Get all contacts
  getContacts(): Contact[] {
    return this.contacts;
  }

  // Add new contact
  addContact(contact: Contact): void {
    this.contacts.push(contact);
  }

  // Get contact by ID
  getContactById(id: number): Contact | undefined {
    return this.contacts.find(c => c.id === id);
  }
}
