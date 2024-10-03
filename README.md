Web Push Notifications API
Este projeto é uma implementação simples de uma API de Notificações Push utilizando o ASP.NET Core e a biblioteca WebPush. Ele permite que os clientes se inscrevam para receber notificações em tempo real.

Funcionalidades
Inscrição para Notificações: Os usuários podem se inscrever para receber notificações push.
Envio de Notificações: A API pode enviar mensagens para todos os usuários inscritos.
API REST: Implementada seguindo os princípios REST, permitindo fácil integração com front-ends e outros serviços.
Tecnologias Utilizadas
ASP.NET Core: Framework para desenvolvimento de aplicações web.
WebPush: Biblioteca para lidar com o protocolo de Push Notifications.
Swagger: Para documentação e testes da API.
Estrutura do Projeto
1. NotificationsController
Este controlador gerencia a inscrição e o envio de notificações:

Subscribe: Método para adicionar uma nova inscrição de usuário. Recebe um objeto PushSubscription que contém os detalhes da inscrição.

csharp
Copiar código
[HttpPost("subscribe")]
public IActionResult Subscribe([FromBody] PushSubscription subscription)
SendNotification: Método para enviar notificações a todos os usuários inscritos. Recebe uma mensagem como string e a envia utilizando o cliente WebPush.

csharp
Copiar código
[HttpPost("send")]
public async Task<IActionResult> SendNotification([FromBody] string message)
2. Configuração da API
A API é configurada em um arquivo Program.cs, onde os controladores são registrados e as rotas são mapeadas.

csharp
Copiar código
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // Habilita controladores
3. Modelo de Dados
A classe NotificationMessage é um exemplo de modelo para as mensagens de notificação que podem ser enviadas.

csharp
Copiar código
public class NotificationMessage
{
    public string Body { get; set; }
}
Como Executar o Projeto
Clone o repositório:

bash
Copiar código
git clone https://github.com/seu-usuario/nome-do-repositorio.git
cd nome-do-repositorio
Restaure as dependências:

bash
Copiar código
dotnet restore
Execute a aplicação:

bash
Copiar código
dotnet run
Acesse a API em https://localhost:5001/api/notifications.

Uso
Inscrição para Notificações
Para se inscrever, envie uma requisição POST para /api/notifications/subscribe com o corpo contendo os detalhes da PushSubscription.

Envio de Notificações
Para enviar uma notificação, faça uma requisição POST para /api/notifications/send com a mensagem que deseja enviar.

Contribuição
Sinta-se à vontade para contribuir! Abra um pull request ou crie uma issue para discutir melhorias.

Licença
Este projeto está licenciado sob a MIT License. Veja o arquivo LICENSE para mais detalhes.
