import { Pipe, PipeTransform } from '@angular/core';
import { Tamanho } from './atividade';

@Pipe({ name: 'tamanhoToString' })
export class TamanhoToStringPipe implements PipeTransform {
  transform(tamanho: Tamanho): string {
    switch (tamanho) {
      case Tamanho.P:
        return 'P';
      case Tamanho.M:
        return 'M';
      case Tamanho.G:
        return 'G';
      default:
        return 'XG';
    }
  }
}
