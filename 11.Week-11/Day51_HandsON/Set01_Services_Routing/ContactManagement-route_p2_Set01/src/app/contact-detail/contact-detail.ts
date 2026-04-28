import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContactService } from '../contact-service';

@Component({
  selector: 'app-contact-detail',
  imports: [CommonModule],
  templateUrl: './contact-detail.html',
  styleUrl: './contact-detail.css',
})
export class ContactDetail {
  contact :any;
  
  constructor(private route:ActivatedRoute, private service:ContactService){
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.contact =this.service.getContactById(id);
  }
}
