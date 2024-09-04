import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IntegranteComponent } from './integrante/integrante.component';
import { IntegranteAnaliticsComponent } from './integrante/analitics/integrante-analitics.component';
import { ComposicaoComponent } from './composicao/composicao.component';

const routes: Routes = [
  {title:"Integrante",path:"integrante", component: IntegranteComponent},
  {title:"Integrante | Analise",path:"integrante-analitics", component: IntegranteAnaliticsComponent},
  {title:"Composicão",path:"composicao", component: ComposicaoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
