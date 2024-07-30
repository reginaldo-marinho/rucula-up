import { Injectable } from '@angular/core';
import { TabulatorFull} from 'tabulator-tables';

@Injectable({
  providedIn: 'root'
})
export class TabulatorService {
  
  public create(selector:string, options:any){
    
    var table = new TabulatorFull(selector, {
      rowHeight:40,
      layout:"fitColumns",
      data:JSON.parse(options.data),
        columns:options.columns,
      }); 

      return table
    
  }
}
