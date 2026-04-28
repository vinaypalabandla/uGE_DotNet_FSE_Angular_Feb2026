import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Contact } from '../contact';
import { ContactService } from '../contact-service';

@Component({
  selector: 'app-contact-detail',
  imports: [CommonModule],
  templateUrl: './contact-detail.html',
  styleUrl: './contact-detail.css',
})
export class ContactDetail {
  contact?: Contact;

  constructor(private service:ContactService){
    this.contact = this.service.getContactById(501);
  }
}
