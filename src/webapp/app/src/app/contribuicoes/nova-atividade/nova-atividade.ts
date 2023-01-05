export interface NovaAtividade {
  descricao: string;
  nome: string;
  tamanho: number;
  dataDaExecucao: string;
  organizador: Organizador;
}

interface Organizador {
  idDeUsuario: string;
  nome: string;
}
