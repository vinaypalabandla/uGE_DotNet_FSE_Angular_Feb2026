import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ContactService } from '../contact-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-contact',
  imports: [FormsModule],
  templateUrl: './add-contact.html',
  styleUrl: './add-contact.css',
})
export class AddContact {
  contact = {id:0, name:'',email:'',phone:''};

  constructor(private service: ContactService, private router:Router){}

   add() {
    this.service.addContact(this.contact);
    this.router.navigate(['/contacts']);
  }
}
