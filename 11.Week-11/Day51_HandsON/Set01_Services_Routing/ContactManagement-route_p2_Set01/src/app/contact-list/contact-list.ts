import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ContactService } from '../contact-service';

@Component({
  selector: 'app-contact-list',
  imports: [CommonModule,RouterLink],
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css',
})
export class ContactList {
  contacts:any[] =[];

  constructor(private service :ContactService) {
    this.contacts = this.service.getContacts();
  }
}
