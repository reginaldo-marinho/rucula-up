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
      super({
         target:"js",
         rw:rw,
         reload: () => {
          this.startGrid()
         }
      })
    }
    
    integranteGrid!:IntegranteGrid
    
    startGrid(){
      this.integranteGrid = new IntegranteGrid(this.rucula,this.http,this.tab);
      this.integranteGrid.init();
    }

    ngOnInit(): void {
      
      this.init();
      this.startGrid()

      this.rucula.event.on('r-analise',() => this.router.navigate(['/integrante-analitics']))
      this.rucula.event.on('r-composicao',() => this.router.navigate(['/composicao']))
    }
    
    protected override save(e: CustomEvent): void {      

      this.http.post<Integrante>(e.detail.url,e.detail.body)
        .subscribe(() => 
          this.rucula.popup.sucess({
            text:'Integrante Registrado 👍🏻😃'
          })
        ) 
    } 

    protected override alter(e: CustomEvent): void {
      this.http.put<Integrante>(e.detail.url,e.detail.body)
        .subscribe(() => 
          this.rucula.popup.sucess({
            text:'Integrante Alterado 👍🏻😃',
          })
        ) 
    }

    protected override delete(e: CustomEvent): void {
      this.http.delete(e.detail.url)
        .subscribe(() => 
          this.rucula.popup.sucess({
            text:'Integrante Removido 👍🏻😃'

          })
        ) 
    }
}