import { Rucula } from "@reginaldo-marinho/dist/Rucula"
import { configurationRucula } from "src/global/configurationRucula"

export abstract class RuculaCrudManagment {
    
    private target:string
    private rw: any
    protected rucula!:Rucula
    private reload:any
    constructor(config:{
        target:string,
        rw: any, 
        reload?:any
    }){
        
        this.target = config.target
        this.rw = config.rw
        this.reload = config?.reload
    }
    protected init(){

        this.rucula = new Rucula({
            global: configurationRucula as any,
            window: this.rw ,
            id: this.target ,
            reload: this.reload
        })

        this.rucula.event.on('r-a-save',(e:CustomEvent) => this.save(e));  
        this.rucula.event.on('r-a-alter',(e:CustomEvent) => this.alter(e));  
        this.rucula.event.on('r-a-delete',(e:CustomEvent) => this.delete(e));  
    }
    
    protected abstract save(e:CustomEvent):void
    protected abstract alter(e:CustomEvent):void
    protected abstract delete(e:CustomEvent):void

}