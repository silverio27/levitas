import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Atividade } from './atividade';
import { NovaAtividade } from './nova-atividade/nova-atividade';

const uri = 'https://localhost:7247/atividade';
@Injectable({ providedIn: 'root' })
export class AtividadesService {
  constructor(private http: HttpClient) {}

  obterTodasAtividaades(): Observable<Atividade[]> {
    return this.http.get<Atividade[]>(uri);
  }

  incluirNovaAtividade(novaAtividade: NovaAtividade) {
    return this.http.post(uri, novaAtividade);
  }

  obterAtividadePeloId(id: string): Observable<Atividade> {
    return this.http.get<Atividade>(`${uri}/${id}`);
  }

  deletarAtividade(id:string) : Observable<any>{
    return this.http.delete<any>(`${uri}/${id}`);
  }
}
