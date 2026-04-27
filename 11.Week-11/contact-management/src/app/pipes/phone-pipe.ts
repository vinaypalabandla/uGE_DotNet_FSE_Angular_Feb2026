import { Pipe, PipeTransform } from '@angular/core';
import { retry } from 'rxjs';

@Pipe({
  name: 'phone',
})
export class PhonePipe implements PipeTransform {
 transform(value: string):string {
  //checking the value exists or not 
  if(!value){
    return '';
  }
   //parts of number 
   const first = value.slice(0,3);
   const second = value.slice(3,6);
   const third =value.slice(6,10);
   //join with dashes
   return first + '-' + second + '-' + third;
 
  }
}
