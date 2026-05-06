import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { ContactService } from '../../services/contact-service';
import { Contact } from '../../models/contact';

@Component({
  selector: 'app-contact-details',
  imports: [RouterModule],
  templateUrl: './contact-details.html',
  styleUrl: './contact-details.css',
})
export class ContactDetails implements OnInit {
  contact!: Contact;

  constructor(
    private service: ContactService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    this.service.getContactById(id).subscribe(data => {
      this.contact = data;
    });
  }
}
