import { Rucula } from "@reginaldo-marinho/rucula-js";
import { Query, QueryInit,gridConfig } from "./query";
import { HttpGenericService } from "../http-generic/http-generic.service";
import { TabulatorService } from "../tabulator/tabulator.service";

export class IntegranteGrid extends Query implements QueryInit {
  
    constructor(rucula:Rucula, http:HttpGenericService, tab:TabulatorService) {
        
      let gridConfig:gridConfig = {
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
            
    protected override url(): string {
      return `${this.rucula.url().domain()}/Query`
    }


    protected override setData(e: any, row:any): void {
      
      let id = row._row.data['Id']
      
      let url = this.rucula.url({
          absolute:'',
          relative:'Integrante',
          params:`id=${id}`
      }).getURL()

      this.http.get(url).subscribe(integrante => {
        
        this.rucula.object.setValue(propert('id'), integrante.id);
        this.rucula.object.setValue(propert('nome'), integrante.nome);
        this.rucula.object.setValue(propert('telefoneCelular'), integrante.telefoneCelular);
        this.rucula.object.setValue(propert('serveNaIgreja'), integrante.serveNaIgreja);
        this.rucula.object.setValue(propert('batizado'), integrante.batizado);
        this.rucula.object.setValue(propert('estadoCivil'), integrante.estadoCivil);
        this.rucula.object.setValue(propert('ministerio'), integrante.ministerio);
     
      })

      function propert(prop:string){
        return `aliasIntegrante.${prop}`
      }

    }
}