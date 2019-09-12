# Interview GSW

## Instruções

1. Faça um fork deste repositório;
2. Envie um e-mail informando a data para finalização do chamado;
3. Crie uma branch com o seu nome;
4. Envie-nos o PULL-REQUEST para que seja avaliado.

### O teste

Trata-se de uma aplicação que simula a entrega de notas quando um cliente efetua um saque em um caixa eletrônico. 

Os requisitos básicos são os seguintes:

 1. Entregar o menor número de notas;
 2. Somente será possível sacar o valor solicitado com as notas disponíveis;
 3. Saldo do cliente será cadastrado (apenas o administrador poderá fazer isso); 
 4. Quantidade de notas infinita;
 5. Notas disponíveis de R$ 100,00; R$ 50,00; R$ 20,00 e R$ 10,00 
 6. O Cliente não poderá entrar no negativo;
 7. Fazer o CRUD de cliente juntamente com seu saldo;
 8. Garantir no máximo 5 usuários ao mesmo tempo.

Não estamos exigindo layout e também arquitetura do projeto, porém, isso será um diferencial.

### Outros Requisitos:
* Para a persistência dos dados deve ser utilizado o Dapper ou Entity Core.
* Configurar o Swagger na aplicação
* Usar Microsfot SqlServer 2014 ou superior.
* Gerar Scripts e disponibilizá-los um uma pasta.

### Observações:
* O sistema deverá ser desenvolvido na plataforma .NET com C#, usando o framework ASP.NET (Core/Full ramework)
* Deve conter autenticação com dois níveis de acesso, um administrador e um público, o usuário de nível 
público não terá autenticação, ou seja, terá acesso livre;


### Diferencial:
* Implementar front-end para consumir a API em  Angular/React como framework Javascript.
* Aplicação das boas práticas do DDD, TDD, Design Patterns, SOLID e Clean Code.
obs: Teste terá como avaliação principal os requisitos solicitados para o backend,  porém o frontend 
poderá ser critério de desempate.

### Instruções

Você deve baixar o projeto, **criar uma branch nova com o seu nome**, trocar esse readme com as intruções para rodar este projeto e após isso criar um pull request para a master quando tiver finalizado.
O projeto atualmente não 'builda' e nem compila.

Exemplo:
- Baixar os pacotes Nuget
- Publicar o projeto, publicar a WebAPI;
- Instalar o pacote XYZ do node
- Compilar o Angular/React;
- Fazer os testes da aplicação;
- Aplicar melhorias e testes se achar necessário.

Lembre-se da portabilidade da aplicação. Quanto mais fácil for para subir a aplicação para quem for fazer a correção, melhor você será avaliado.

**Após baixar e analisar esse projeto, responda com um e-mail o prazo que você levará para concluí-lo.**