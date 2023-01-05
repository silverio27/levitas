import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-confirmar-delecao-atividade',
  templateUrl: './confirmar-delecao-atividade.component.html',
  styleUrls: ['./confirmar-delecao-atividade.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ConfirmarDelecaoAtividadeComponent {
  constructor(public dialogRef: MatDialogRef<ConfirmarDelecaoAtividadeComponent>) {}
}
