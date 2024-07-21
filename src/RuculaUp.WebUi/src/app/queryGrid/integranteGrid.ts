import { Rucula } from "@reginaldo-marinho/rucula-js";
import { Query, QueryInit } from "./query";
import { HttpGenericService } from "../http-generic/http-generic.service";
import { TabulatorService } from "../tabulator/tabulator.service";

export class IntegranteGrid extends Query implements QueryInit {

    constructor(rucula:Rucula, private http:HttpGenericService, private tab:TabulatorService) {
        super(rucula, "IntegranteQueryPaged");
    }
  
    init(): void {
      
      this.inputOptions.options = JSON.stringify({
        LastId:"", 
        LastNome:""
      })

      this.queryView()
    }

    protected override queryView() {

        this.http.post<any>("http://localhost:5270/Query", this.inputOptions)
        .subscribe(result => {

          this.inputOptions.options = result.options

          this.tab.create(".r-act-grid-body", { 
            columns:[
              {title:"Id", field:"Id", width:140},
              {title:"Nome", field:"Nome",  width: 200},
              {title:"Ministerio", field:"Ministerio",  width:200},
            ],
            data: result.data
          })
          
        });
    }     
}