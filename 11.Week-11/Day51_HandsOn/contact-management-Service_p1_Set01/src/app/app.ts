
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PhonePipe } from './pipes/phone-pipe';
import { StatusPipe } from './pipes/status-pipe';
import { SearchPipe } from './pipes/search-pipe';
import { CommonModule, LowerCasePipe, NgClass, NgFor, SlicePipe, TitleCasePipe } from '@angular/common';
import { ContactList } from './contact-list/contact-list';
import { ContactDetail } from './contact-detail/contact-detail';
import { AddContact } from './add-contact/add-contact';

@Component({
  selector: 'app-root',
   standalone: true,
  imports: [CommonModule,FormsModule,PhonePipe,StatusPipe,SearchPipe,NgClass, TitleCasePipe, LowerCasePipe,SlicePipe, NgFor,ContactList,ContactDetail,AddContact],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
// searchText ='';
// showCount =5;

// contacts = [
//   {name:'vinay kuamr', email:'vinay@gmail.com',phone:'9875858569',status:true},
//       { name: 'rahul reddy', email: 'rahul@gmail.com', phone: '9123456780', status: false },
//     { name: 'sita devi', email: 'sita@gmail.com', phone: '9988776655', status: true },
//     { name: 'arjun', email: 'arjun@gmail.com', phone: '8899776655', status: false },
//     { name: 'kiran', email: 'kiran@gmail.com', phone: '7788996655', status: true },
//     { name: 'meena', email: 'meena@gmail.com', phone: '6677889955', status: true },
//     { name: 'ravi', email: 'ravi@gmail.com', phone: '5566778899', status: false },
//     { name: 'anil', email: 'anil@gmail.com', phone: '4455667788', status: true },
//     { name: 'deepa', email: 'deepa@gmail.com', phone: '3344556677', status: false },
//     { name: 'surya', email: 'surya@gmail.com', phone: '2233445566', status: true }

// ];
// buttonStatus(c:any){
//   c.status =!c.status;
// }
// showMore(){
//   this.showCount = this.contacts.length;
// }
// showLess() {
//   this.showCount =5;
// }
}
