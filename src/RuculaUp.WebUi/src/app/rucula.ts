import { Rucula } from "@reginaldo-marinho/rucula-js"
import { configurationRucula } from "src/global/configurationRucula"

export abstract class RuculaCrudManagment {
    
    private target:string
    private rw: any
    protected rucula!:Rucula
    
    constructor(target:string, rw: any){
        
        this.target = target
        this.rw = rw
    }
    protected init(){
        this.rucula = new Rucula(configurationRucula as any, this.rw, this.target)!
        this.rucula.event.on('r-a-save',(e:CustomEvent) => this.save(e));  
        this.rucula.event.on('r-a-alter',(e:CustomEvent) => this.alter(e));  
        this.rucula.event.on('r-a-delete',(e:CustomEvent) => this.delete(e));  
    }
    
    protected abstract save(e:CustomEvent):void
    protected abstract alter(e:CustomEvent):void
    protected abstract delete(e:CustomEvent):void

}