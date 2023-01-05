
export interface Atividade {
  id: string;
  criadoEm: string;
  criador: Criador;
  ultimaAlteracao: string;
  historico: Historico[];
  nome: string;
  descricao: string;
  status: StatusDaAtividade;
  contribuidores: Contribuidores[];
  fotos: Foto[];
  tamanho: Tamanho;
  duracao: string;
  dataDaExecucao: string;
  pontos: number;
}
export enum StatusDaAtividade{
  Afazer,
  Concluido
}
interface Foto {
  id: string;
  criadoEm: string;
  criador: Criador;
  ultimaAlteracao: string;
  descricao: string;
  sessao: string;
  nome: string;
}

export enum Tamanho{
  P,
  M,
  G,
  XG
}
export interface Contribuidores {
  id: string;
  criadoEm: string;
  criador: Criador;
  ultimaAlteracao: string;
  idDeUsuario: string;
  nome: string;
  consentiuComOsTermos: boolean;
  recrutador: Criador;
  status: number;
}
interface Historico {
  mensagem: string;
}
interface Criador {
  idDeUsuario: string;
  nome: string;
}
