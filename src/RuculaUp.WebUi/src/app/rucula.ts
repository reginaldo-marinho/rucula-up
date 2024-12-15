import { buttonURL } from "@reginaldo-marinho/dist/entities/form/button"
import { Rucula } from "@reginaldo-marinho/dist/Rucula"
import { configurationRucula } from "src/global/configurationRucula"


export abstract class RuculaCrudManagment {
    
    private target:string
    private windowOrPath: any
    protected rucula!:Rucula
    private reload:any

    constructor(config:{
        target:string,
        windowOrPath: any, 
        reload?:any}){
        
        this.target = config.target
        this.windowOrPath = config.windowOrPath
        this.reload = config?.reload
    }

    protected async init(){

        var config = {
            global: configurationRucula as any,
            id: this.target ,
            reload: this.reload
        } as any;

        if(typeof this.windowOrPath === 'string'){
            config.urlWindow = {
                relative:`ui?window=${this.windowOrPath}`
            } as buttonURL
        }else{
            config.window = this.windowOrPath;
        }

        this.rucula = new Rucula(config)
        
        await this.rucula.init()

        this.rucula.event.on('r-a-save',(e:CustomEvent) => this.save(e));  
        this.rucula.event.on('r-a-alter',(e:CustomEvent) => this.alter(e));  
        this.rucula.event.on('r-a-delete',(e:CustomEvent) => this.delete(e));  
    }
    
    protected abstract save(e:CustomEvent):void
    protected abstract alter(e:CustomEvent):void
    protected abstract delete(e:CustomEvent):void

}