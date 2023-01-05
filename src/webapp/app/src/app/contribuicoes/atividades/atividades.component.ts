import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { Atividade } from '../atividade';
import { AtividadesService } from '../atividades.service';

@Component({
  templateUrl: './atividades.component.html',
  styleUrls: ['./atividades.component.css'],
})
export class AtividadesComponent implements OnInit {
  atividadesLista: Atividade[] = [];
  filtros = this._formBuilder.group({
    afazer: true,
    concluido: true,
    start: new FormControl<Date | null>(null),
    end: new FormControl<Date | null>(null),
  });

  constructor(
    public atividades: AtividadesService,
    private _formBuilder: FormBuilder
  ) {}

  ngOnInit() {
    this.obterTodasAtividades();
  }

  obterTodasAtividades() {
    this.atividades.obterTodasAtividaades().subscribe({
      next: (resposta) => {
        this.atividadesLista = resposta;
      },
      error: (erro) => {
        console.log(erro);
      },
      complete: () => {},
    });
  }
}
