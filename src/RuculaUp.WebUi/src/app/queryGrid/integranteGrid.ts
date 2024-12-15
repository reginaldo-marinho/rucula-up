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
      this.dataGrid()
    }
            
    protected override url(): string {
      return `${this.rucula.url({}).domain()}/Query`
    }
    
    protected override setData(e: any, row:any): void {
      
      let id = row._row.data['Id']
      
      let url = this.rucula.url({
          absolute:'',
          relative:'Integrante',
          params:`id=${id}`
      }).getURL()

      this.http.get(url).subscribe(integrante => {
        this.rucula.setValue(AlIntegrante('id'), integrante.id);
        this.rucula.setValue(AlIntegrante('nome'), integrante.nome);
        this.rucula.setValue(AlIntegrante('telefoneCelular'), integrante.telefoneCelular);
        this.rucula.setValue(AlIntegrante('serveNaIgreja'), integrante.serveNaIgreja);
        this.rucula.setValue(AlIntegrante('batizado'), integrante.batizado);
        this.rucula.setValue(AlIntegrante('dataDeNascimento'), new Date(integrante.dataDeNascimento).toISOString().split('T')[0]);
        this.rucula.setValue(AlIntegrante('estadoCivil'), integrante.estadoCivil);
        this.rucula.setValue(AlIntegrante('ministerio'), integrante.ministerio);
        this.rucula.setValue(AlEndereco('rua'), integrante.endereco.rua);
        this.rucula.setValue(AlEndereco('bairro'), integrante.endereco.bairro);
        this.rucula.setValue(AlEndereco('cidade'), integrante.endereco.cidade);
     
      })

      function AlIntegrante(prop:string){
        return `aliasIntegrante.${prop}`
      }
      function AlEndereco(prop:string){
        return `aliasEndereco.${prop}`
      }

    }
}