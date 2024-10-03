# Web Push Notifications API

Este projeto é uma implementação simples de uma API de Notificações Push utilizando o ASP.NET Core e a biblioteca WebPush. Ele permite que os clientes se inscrevam para receber notificações em tempo real.

## Funcionalidades

- **Inscrição para Notificações**: Os usuários podem se inscrever para receber notificações push.
- **Envio de Notificações**: A API pode enviar mensagens para todos os usuários inscritos.
- **API REST**: Implementada seguindo os princípios REST, permitindo fácil integração com front-ends e outros serviços.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework para desenvolvimento de aplicações web.
- **WebPush**: Biblioteca para lidar com o protocolo de Push Notifications.
- **Swagger**: Para documentação e testes da API.

## Estrutura do Projeto

### 1. NotificationsController

Este controlador gerencia a inscrição e o envio de notificações:

- **`Subscribe`**: Método para adicionar uma nova inscrição de usuário. Recebe um objeto `PushSubscription` que contém os detalhes da inscrição.

    ```csharp
    [HttpPost("subscribe")]
    public IActionResult Subscribe([FromBody] PushSubscription subscription)
    ```

- **`SendNotification`**: Método para enviar notificações a todos os usuários inscritos. Recebe uma mensagem como string e a envia utilizando o cliente WebPush.

    ```csharp
    [HttpPost("send")]
    public async Task<IActionResult> SendNotification([FromBody] string message)
    ```

### 2. Configuração da API

A API é configurada em um arquivo `Program.cs`, onde os controladores são registrados e as rotas são mapeadas.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // Habilita controladores

#### 3. Modelo de Dados

A API utiliza alguns modelos para gerenciar as informações necessárias para as notificações. Aqui estão os principais modelos utilizados:

##### 3.1 PushSubscription

O modelo `PushSubscription` contém os detalhes da assinatura do usuário para notificações push. Geralmente, inclui informações como endpoint, chaves e outros parâmetros necessários para a entrega das notificações. Este modelo é essencial para gerenciar as inscrições.

```csharp
public class PushSubscription
{
    public string Endpoint { get; set; }
    public string P256dh { get; set; }
    public string Auth { get; set; }
}

## Referências para Web Push Notifications

1. **[MDN Web Docs - Push Notifications](https://developer.mozilla.org/en-US/docs/Web/API/Push_API)**  
   Documentação oficial da Mozilla sobre como implementar e usar Push Notifications em aplicações web.

2. **[Google Developers - Push Notifications](https://developers.google.com/web/fundamentals/push-notifications)**  
   Guia completo da Google sobre Push Notifications, incluindo exemplos de implementação e melhores práticas.

3. **[Web Push Libraries](https://web-push-codelab.glitch.me/)**  
   Uma lista de bibliotecas populares para trabalhar com Web Push Notifications em diferentes linguagens e frameworks.

4. **[Web Push Protocol](https://tools.ietf.org/html/draft-ietf-webpush-protocol-15)**  
   Especificação do protocolo Web Push, que descreve como enviar notificações para navegadores.

5. **[VAPID (Voluntary Application Server Identification)](https://developer.mozilla.org/en-US/docs/Web/API/Push_API#vapid)**  
   Documentação sobre VAPID, que é um método de autenticação para enviar notificações push.

6. **[Push API - MDN Web Docs](https://developer.mozilla.org/en-US/docs/Web/API/Push_API)**  
   Documentação detalhada do Push API, que permite que um servidor envie mensagens para o navegador do usuário.

7. **[Service Workers - MDN Web Docs](https://developer.mozilla.org/en-US/docs/Web/API/Service_Worker_API)**  
   A importância dos Service Workers para a implementação de Push Notifications, incluindo como registrar e gerenciar Service Workers.

