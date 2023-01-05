import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { Atividade } from '../atividade';

@Component({
  selector: 'atividade-thumbnail',
  templateUrl: './atividade-thumbnail.component.html',
  styleUrls: ['./atividade-thumbnail.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AtividadeThumbnailComponent {
  @Input() atividade: Atividade = {} as Atividade;
}
