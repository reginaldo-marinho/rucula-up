import { Rucula } from "@reginaldo-marinho/rucula-js";
import { TabulatorService } from "../tabulator/tabulator.service";
import { HttpGenericService } from "../http-generic/http-generic.service";

export abstract class Query {
    
    private pageOption:any = {
        first: 0,
        last:3,
        next:2,
        previous:1,
        find:4
    }

    private inputOptions: inputOptions;
    private gridConfig:gridConfig
    protected rucula:Rucula
    protected tab:TabulatorService
    protected http:HttpGenericService

    constructor(http:HttpGenericService, rucula:Rucula, tab:TabulatorService, name:string, gridConfig:gridConfig) {
        
        this.http = http
        this.rucula = rucula
        this.tab = tab
        this.gridConfig = gridConfig
        
        this.inputOptions = {
            name: name,
            rowNumber: 50,
            page: 0,
            options: '{}',
            text:''
        }    
        
        this.configureOptions()
    }
    
    private configureOptions(){
        
        this.rucula.event.on('r-pagination',(e:CustomEvent)=> {
            
            let page = e.detail.page
            this.inputOptions.page = this.pageOption[page]
            this.dataGrid()
        })
        
        this.rucula.event.on('r-pagination-find',(e:CustomEvent)=> {
            this.inputOptions.text = e.detail.value
            this.inputOptions.page = this.pageOption.find
            this.dataGrid()
        })
    
          this.rucula.event.on('r-pagination-row',(e:CustomEvent)=> {

              let row = e.detail.row
              this.inputOptions.rowNumber = Number(row)
              this.dataGrid()
            })
    }
        
    protected dataGrid(){
        
        this.http.post<any>(this.url(), this.inputOptions)
        .subscribe(result => {

          this.inputOptions.options = result.options

          var tabulator = this.tab.create(".r-act-grid-body", { 
            columns:this.gridConfig.columns,
            data: result.data
          })

          tabulator.on('rowClick',(e, row) => this.setData(e,row))
        });
    }

    protected abstract setData(e:any, row:any):void;
    protected abstract url():string;

}

export type inputOptions = {
    name: string,
    rowNumber: number,
    page: number,
    options: string,
    text:string
    
}

export interface QueryInit{
    init():void;
}


export type gridConfig = {
    columns: any
    inputConfig: any
}

