import { Rucula } from "@reginaldo-marinho/rucula-js";
import { Query, QueryInit,gridConfig } from "./query";
import { HttpGenericService } from "../http-generic/http-generic.service";
import { TabulatorService } from "../tabulator/tabulator.service";

export class IntegranteGrid extends Query implements QueryInit {
    protected override setData(e: any): void {
      throw new Error("Method not implemented.");
    }
   
    constructor(rucula:Rucula, http:HttpGenericService, tab:TabulatorService) {
        

      let gridConfig:gridConfig = {
        URL:"http://localhost:5270/Query",
        inputConfig: JSON.stringify({
         LastId:"", 
         LastNome:""
       }),
        columns: [
          {title:"Id", field:"Id", width:140},
          {title:"Nome", field:"Nome",  width: 200},
          {title:"Ministerio", field:"Ministerio",  width:200},
        ]
      } 
      super(http,rucula, tab, "IntegranteQueryPaged",gridConfig)
    }
  
    init(): void {
      this.dataGrid()
    }

  
}