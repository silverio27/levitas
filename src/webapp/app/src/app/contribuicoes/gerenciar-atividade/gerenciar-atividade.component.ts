import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { of, switchMap } from 'rxjs';
import { Atividade, StatusDaAtividade } from '../atividade';
import { AtividadesService } from '../atividades.service';
import { ConfirmarDelecaoAtividadeComponent } from '../confirmar-delecao-atividade/confirmar-delecao-atividade.component';

@Component({
  templateUrl: './gerenciar-atividade.component.html',
  styleUrls: ['./gerenciar-atividade.component.css'],
})
export class GerenciarAtividadeComponent {
  id: any;
  atividade = { nome: '', criador: { idDeUsuario: '', nome: '' } } as Atividade;
  displayedColumns: string[] = [
    'nome',
    'consentiuComOsTermos',
    'recrutador',
    'status',
  ];
  statusConcluido: StatusDaAtividade = StatusDaAtividade.Concluido;

  constructor(
    route: ActivatedRoute,
    private router: Router,
    private atividadeService: AtividadesService,
    public dialog: MatDialog
  ) {
    route.params
      .pipe(
        switchMap((x) => {
          this.id = x['id'];
          return atividadeService.obterAtividadePeloId(this.id);
        })
      )
      .subscribe({
        next: (resposta) => {
          this.atividade = resposta;
        },
      });
  }

  deletar() {

    this.dialog
      .open(ConfirmarDelecaoAtividadeComponent, {
        width: '250px',
      })
      .afterClosed()
      .pipe(
        switchMap((resposta: boolean) => {
          if (resposta) return this.atividadeService.deletarAtividade(this.id);
          else return of<Object>({});
        })
      )
      .subscribe({
        next: () => {

          this.router.navigate(['contribuicoes']);
        },
      });
  }
}
