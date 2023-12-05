
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class FormatterService {
  constructor() { }
  
  SI_SYMBOL = ["", "k", "M", "G", "T", "P", "E"];


  public kFormatter =  (number) => {
     // what tier? (determines SI symbol)
     var tier = Math.log10(Math.abs(number)) / 3 | 0;

     // if zero, we don't need a suffix
     if(tier == 0) return number;
 
     // get suffix and determine scale
     var suffix = this.SI_SYMBOL[tier];
     var scale = Math.pow(10, tier * 3);
 
     // scale the number
     var scaled = number / scale;
 
     // format number and add suffix
     return scaled.toFixed(3) + suffix;
  }

  public CommaFormatter =  (number) => {
    return number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
 }
}
