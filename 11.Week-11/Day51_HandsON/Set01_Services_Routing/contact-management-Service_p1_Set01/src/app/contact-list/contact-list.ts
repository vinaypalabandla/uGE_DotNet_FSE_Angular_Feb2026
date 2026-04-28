import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ContactService } from '../contact-service';
import { Contact } from '../contact';
@Component({
  selector: 'app-contact-list',
  imports: [CommonModule], 
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css',
})
export class ContactList {
  contacts : Contact[] = [];
   
  constructor(private service : ContactService){
      this.contacts = this.service.getContacts();
  }
}
