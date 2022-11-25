# Gestão de pontos

[voltar](/./README.md)

> A moeda da associação são os pontos obtidos pela execução das tarefas. Esses pontos podem ser trocados por peças na loja da Levitas (OSC). As peças são repassadas a preço de custo para os atletas. Exemplo: A associação adquiriu um shape diretamente com o fornecedor no valor de R$70.00. Para um atleta conseguir fazer a troca ele terá que obter 13 pontos. Cada ponto vale R$5,51, valor da hora do salário mínimo atual, 13 x R$5,51 = R$71,63.

## Funcionalidades

| Nome | Observação | Tamanho
| --- | --- | ---
| Atualizar valor dos pontos | | P
| Ganhar pontos |Acontece sempre que uma atividade é concluída. Os pontos acordados na atividade são atribuídos aocontribuidor. | P
| Perder pontos | Acontece quando o contribuidor falta na atividade acordada | P
| Meus pontos | Exibir para o contribuidor o histórico de atividades em que ele participou e o resultado dasatividades. | G
| Todos pontos | Exibir para os organizadores o histórico de atividades, resultado e ranking de pontos porcontribuidor | G

**Estimativa** : 11 dias

## Definições de pronto

[história](../historia/capina.md#gestão-de-pontos)

Os pontos devem estar valendo o valor da hora com base no salário mínimo atual (R$5.51).

A consulta **Todos pontos** deve estar da seguinte maneira:

| Nome | Ponto | Ingressados | Saiu | Faltou | Link para o perfil
| ---  | --- | --- | --- | --- | ---
| Dyego | 4 | 1 | 0 | 0 | link
| Lucas | 0 | 0 | 0 | 0 | link
| Felix | 4 | 1 | 0 | 0 | link
| Nathan | 4 | 1 | 0 | 0 | link
| Icaro | 0 | 1 | 0 | 0 | link
| André | -4 | 1 | 0 | 1 | link
| Jhuan | 0 | 1 | 1 |0 | link

A consulta **Meus pontos** retorna os dados do Nathan da seguinte maneira:

|Nome | Email | Pontos
|---  |--- | ---
|Nathan|nathan@email.com | 4

## Atividades

|Nome | Quando | Link | Pontos
|---  |---     |---   |---
|Capina | 13/11/2022 | Url da atividade | 4
