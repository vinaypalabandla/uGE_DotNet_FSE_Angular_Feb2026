import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';

@Component({
  selector: 'app-contact-details',
  imports: [CommonModule, RouterModule],
  templateUrl: './contact-details.html',
  styleUrl: './contact-details.css',
})
export class ContactDetails {
    id: number = 0;

  constructor(private route: ActivatedRoute) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
  }
}
