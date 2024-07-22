import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import * as rw from 'src/app/integrante/integrante.rucula.json'
import { HttpGenericService } from '../http-generic/http-generic.service';
import { Integrante } from './Integrante';
import { TabulatorService } from '../tabulator/tabulator.service';
import {  RuculaCrudManagment } from '../rucula';
import { IntegranteGrid } from '../queryGrid/integranteGrid';


@Component({
  template: `<div id="js"><div>`,
  providers:[HttpGenericService]
})

export class IntegranteComponent extends RuculaCrudManagment implements OnInit {
   
    constructor(
      private http:HttpGenericService, 
      private tab:TabulatorService,
      private router: Router
    ) {
      super("js",rw)
    }
    
    integranteGrid!:IntegranteGrid
    
    ngOnInit(): void {
      
      this.init();
      this.integranteGrid = new IntegranteGrid(this.rucula,this.http,this.tab);
      this.integranteGrid.init();

      this.rucula.event.on('r-analise',() => this.router.navigate(['/integrante-analitics']))
    }
    
    protected override save(e: CustomEvent): void {      

      this.http.post<Integrante>(e.detail.url+'/Integrante',e.detail.body)
        .subscribe(() => 
          this.rucula.popup.messsage.sucess({
            text:'Integrante Registrado 👍🏻😃',
            disableadFooter:true,
            timeout:2000
          })
        ) 
    } 

    protected override alter(e: CustomEvent): void {
      this.http.put<Integrante>(e.detail.url+'/Integrante',e.detail.body)
        .subscribe(() => 
          this.rucula.popup.messsage.sucess({
            text:'Integrante Alterado 👍🏻😃',
            disableadFooter:true,
            timeout:2000
          })
        ) 
    }

    protected override delete(e: CustomEvent): void {
      this.http.delete(e.detail.url+`/Integrante?id=${this.rucula.object.getValue('aliasIntegrante.id')}`)
        .subscribe(() => 
          this.rucula.popup.messsage.sucess({
            text:'Integrante Removido 👍🏻😃',
            disableadFooter:true,
            timeout:2000
          })
        ) 
    }

}