import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Tamanho } from '../atividade';
import { AtividadesService } from '../atividades.service';

export const tamanhos = [
  { key: 'P', value: 1 },
  { key: 'M', value: 2 },
  { key: 'G', value: 4 },
  { key: 'XG', value: 8 },
];
@Component({
  templateUrl: './nova-atividade.component.html',
  styleUrls: ['./nova-atividade.component.css'],
})
export class NovaAtividadeComponent {
  atividadeForm!: FormGroup;
  tamanhos = tamanhos;
  constructor(
    private fb: FormBuilder,
    public atividadeService: AtividadesService,
    private router: Router
  ) {
    this.createForm();
  }

  createForm() {
    this.atividadeForm = this.fb.group({
      nome: ['Capina', Validators.required],
      descricao: 'Realizar capina',
      tamanho: Tamanho.P,
      dataDaExecucao: '2022-12-30T08:00:00-03:00',
      organizador: {
        idDeUsuario: '36d2f1ce-6d9a-4b66-a2ea-f05b2757c0bf',
        nome: 'Dyego',
      },
    });
  }

  submit() {
    this.atividadeService
      .incluirNovaAtividade(this.atividadeForm.value)
      .subscribe({
        next: (x:any) => this.router.navigate(['contribuicoes/gerenciar-atividade',x.id]),
      });
  }
}
