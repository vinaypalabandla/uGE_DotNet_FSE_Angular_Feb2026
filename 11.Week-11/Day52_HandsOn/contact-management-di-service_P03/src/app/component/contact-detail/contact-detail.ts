import { Component } from '@angular/core';
import { Contact } from '../../models/contact';
import { ContactService } from '../../services/contact-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-detail',
  imports: [CommonModule],
  templateUrl: './contact-detail.html',
  styleUrl: './contact-detail.css',
})
export class ContactDetail {
  contact?: Contact;

  constructor(private contactService: ContactService) {

    // Level-1 → hardcoded ID
    this.contact = this.contactService.getContactById(1);
  }}
