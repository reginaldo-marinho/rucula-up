import { Rucula } from "@reginaldo-marinho/dist/Rucula";
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
      this.rucula.create()
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
        
        this.rucula.setValue(propert('id'), integrante.id);
        this.rucula.setValue(propert('nome'), integrante.nome);
        this.rucula.setValue(propert('telefoneCelular'), integrante.telefoneCelular);
        this.rucula.setValue(propert('serveNaIgreja'), integrante.serveNaIgreja);
        this.rucula.setValue(propert('batizado'), integrante.batizado);
        this.rucula.setValue(propert('dataDeNascimento'), new Date(integrante.dataDeNascimento).toISOString().split('T')[0]);
        this.rucula.setValue(propert('estadoCivil'), integrante.estadoCivil);
        this.rucula.setValue(propert('ministerio'), integrante.ministerio);
        this.rucula.setValue('aliasEndereco.rua', integrante.endereco.rua);
        this.rucula.setValue('aliasEndereco.bairro', integrante.endereco.bairro);
        this.rucula.setValue('aliasEndereco.cidade', integrante.endereco.cidade);
     
      })

      function propert(prop:string){
        return `aliasIntegrante.${prop}`
      }

    }
}