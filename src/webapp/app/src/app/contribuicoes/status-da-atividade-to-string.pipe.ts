import { Pipe, PipeTransform } from '@angular/core';
import { StatusDaAtividade } from './atividade';

@Pipe({
  name: 'statusDaAtividadeToString'
})
export class StatusDaAtividadeToStringPipe implements PipeTransform {

  transform(status: StatusDaAtividade): string {
    switch (status) {
      case StatusDaAtividade.Afazer:
        
        return 'A Fazer';
    
      default:
        return 'Concluido';
    }
  }

}
