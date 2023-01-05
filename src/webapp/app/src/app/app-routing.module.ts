import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [
    {
        path: 'contribuicoes',
        loadChildren: () => import ('./contribuicoes/contribuicoes.module').then(m => m.ContribuicoesModule)
    }, {
        path: '',
        pathMatch: 'full',
        redirectTo: 'contribuicoes'
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
