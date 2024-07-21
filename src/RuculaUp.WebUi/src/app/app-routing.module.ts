import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IntegranteComponent } from './integrante/integrante.component';

const routes: Routes = [
  {title:"Integrante",path:"integrante", component: IntegranteComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
