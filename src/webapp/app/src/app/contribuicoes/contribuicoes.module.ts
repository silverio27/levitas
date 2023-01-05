import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContribuicoesRoutingModule } from './contribuicoes-routing.module';
import { AtividadesComponent } from './atividades/atividades.component';
import { AtividadeThumbnailComponent } from './atividade-thumbnail/atividade-thumbnail.component';

import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatIconModule} from '@angular/material/icon';
import { MatDividerModule } from "@angular/material/divider";
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule} from '@angular/material/form-field';
import {  MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from "@angular/material/input";
import {MatRadioModule} from '@angular/material/radio';
import {MatTableModule} from '@angular/material/table';
import {MatDialogModule} from '@angular/material/dialog';

import { MAT_DATE_LOCALE } from '@angular/material/core';
import { NovaAtividadeComponent } from './nova-atividade/nova-atividade.component';
import { GerenciarAtividadeComponent } from './gerenciar-atividade/gerenciar-atividade.component';
import { StatusDaAtividadeToStringPipe } from './status-da-atividade-to-string.pipe';
import { TamanhoToStringPipe } from './tamanho-to-string.pipe';
import { ConfirmarDelecaoAtividadeComponent } from './confirmar-delecao-atividade/confirmar-delecao-atividade.component';
@NgModule({
  providers: [
    {provide: MAT_DATE_LOCALE, useValue: 'pt-BR'},
  ],
  declarations: [
    AtividadesComponent,
    AtividadeThumbnailComponent,
    TamanhoToStringPipe,
    StatusDaAtividadeToStringPipe,
    NovaAtividadeComponent,
    GerenciarAtividadeComponent,
    ConfirmarDelecaoAtividadeComponent
  ],
  imports: [
    CommonModule,
    ContribuicoesRoutingModule,
    MatCardModule,
    MatButtonModule,
    MatGridListModule,
    MatIconModule,
    MatDividerModule,
    MatToolbarModule,
    MatCheckboxModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    MatRadioModule,
    MatTableModule,
    MatDialogModule
  ]
})
export class ContribuicoesModule { }
