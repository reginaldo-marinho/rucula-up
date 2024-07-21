import { Rucula } from "@reginaldo-marinho/rucula-js";

export abstract class Query {
    
    private pageOption:any = {
        first: 0,
        last:3,
        next:2,
        previous:1,
        find:4
    }

    private rucula:Rucula
    protected inputOptions: inputOptions;
    
    constructor(rucula:Rucula, name:string, ) {
        
        this.rucula = rucula
        
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
            this.queryView()
        })
        
        this.rucula.event.on('r-pagination-find',(e:CustomEvent)=> {
            this.inputOptions.text = e.detail.value
            this.inputOptions.page = this.pageOption.find
            this.queryView()
        })
    
          this.rucula.event.on('r-pagination-row',(e:CustomEvent)=> {

              let row = e.detail.row
              this.inputOptions.rowNumber = Number(row)
              this.queryView()
            })
        }
        
    protected abstract queryView():void;

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