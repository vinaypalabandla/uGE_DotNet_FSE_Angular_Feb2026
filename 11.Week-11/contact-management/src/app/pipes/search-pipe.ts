import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search',
  standalone: true,
  pure: false 
})
export class SearchPipe implements PipeTransform {
 transform(contacts:any[], searchText:string):any[] {
   if(!searchText) return contacts;
 //here fillter contcats
   return  contacts.filter(c=>
           c.name.toLowerCase().includes(searchText.toLowerCase()) ||
           c.email.toLowerCase().includes(searchText.toLowerCase()));
 
  }
}
