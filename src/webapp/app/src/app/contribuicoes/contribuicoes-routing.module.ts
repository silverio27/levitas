import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AtividadesComponent } from './atividades/atividades.component';
import { GerenciarAtividadeComponent } from './gerenciar-atividade/gerenciar-atividade.component';
import { NovaAtividadeComponent } from './nova-atividade/nova-atividade.component';

const routes: Routes = [{ path: '', component: AtividadesComponent },
{ path: 'nova-atividade', component: NovaAtividadeComponent },
{ path: 'gerenciar-atividade/:id', component: GerenciarAtividadeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContribuicoesRoutingModule { }
