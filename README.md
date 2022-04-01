# grpc-aspnet core
<div id="top"></div>
<br />
  <h2 align="center">gRPC API</h2>

  <p align="center">
    Repositório exemplo gRPC utilizando ASP .NET Core 6.0
  </p>
</div>

## Sobre o projeto

Esse projeto visa a implementação simples do recurso de GRPC para .NET Core 6. Estrutura em RPC de código aberto. GRPC está construído em tecnologias 
como HTTP/2 e Protobuf. Indiferente de plataforma oferece uma linguagem de contrato neutra em termos de linguagem, projeta para aplicatios modernos de alto desempenho.

- GRPC usa HTTP/2
- Protocolo binário mais rápido o que torna mais eficiente. 
- Multiplexação em uma única conexão (várias solicitações podem ser enviadas sem quea s solicitações bloqueiem umas as outras)
- Protobuf, serialização/desserialização mais rápida e menos largura de banda do que outros baseados em texto. 
- Projeto para baixa latêncioa e alta taxa de transferência, ideal para microsserviços leves onde o desempenho é crítico 
- Prazos e timeouts permitem quanto tempo está disposoto a esperar para a conclusão de um RPC. 

## Comunicação entre processos
Chamadas gRPC são enviadas geralmente por soquetes tcp. No entant, se o cliente e servidor estiverem na mesma máquina, o gRPC pode usar o transporte personalizado (*i.e.* *Unix Sockets*, *Name Pipes*, etc) em cenários IPC. 

### Criado com

* [.NET](https://dotnet.microsoft.com/download/dotnet/6.0)


## Pré-Requisitos

Necessário possuir o SDK do .NET Core 6.0:
* Disponível em: https://dotnet.microsoft.com/download/dotnet/6.0

### Configure gRPC client

Os clientes gRPC são tipos concretos gerados através de arquivos .proto. Este tem métodos que traduzem para o serviço gRPC no .proto arquivo. No nosso exemplo, o serviço chamado ```Greeter```gera um ```GreeterClient``` com métodos para chamar o serviço. 

```csharp 
var channel = GrpcChannel.ForAddress("https://localhost:[porta]");
var client = new Greet.GreeterClient(channel);
```

Quando um canal é criado ele representa uma conexão de longa duração com serviço gRPC. Configura por exemplo, o ```HttpClient```usado para fazer as chamadas, o tamnanho máximo do envio e recebimento de mensagens, etc. 

## Configure TLS

Para configurar um canal gRPC para usar TLS, verifique se o endereço com servidor começa com ```https```. O canal gRPC negocia automaticamente uma conexão protegida por TLS e usa uma conexão segura para fazer as chamadas gRPC. Para serviços não seguros ```http```.

## Transient Fault Handling

Você pode tratar exeções do tipo RPC Exceptions para detectar falhas transitórias (como perda de conectividade de rede ou timeout)
e usar lógica integrada para novas tentativas automáticas que podem ser configuradas em um channel. 

```csharp
var defaultMethodConfig = new MethodConfig
{
    Names = { MethodName.Default },
    RetryPolicy = new RetryPolicy
    {
        MaxAttempts = 3,
        InitialBackoff = TimeSpan.FromSeconds(1),
        MaxBackoff = TimeSpan.FromSeconds(5),
        BackoffMultiplier = 1.5,
        RetryableStatusCodes = { StatusCode.Unavailable }
    }
};

var channel = GrpcChannel.ForAddress("https://localhost:7135", new GrpcChannelOptions
{
    ServiceConfig = new ServiceConfig { MethodConfigs = { defaultMethodConfig } }
});
```

## Client-Side Load Balancing

Com o balanceamento de carga do lado do cliente, você pode fazer com que os clientes gRPC distribuam a carga de maneira ideal entre os servidores. Ele elimina a necessida de ter um proxy para balanceamento de carga. 

- Service Discovery: atual com oum resolvedor e faz uma consulta DNS para obter os IPS do servidor onde o gRPC está hospedado
- Balanceador de carga: cria uma conexão e escolhe o endereço usando várias configurações, como lógica PickFirst e RoundRobin. 

```csharp
var channel = GrpcChannel.ForAddress("dns://my-example-host", new GrpcChannelOptions
  {
    Credentials = Channel.Credentials.Insecure,
    ServiceConfig = new ServiceConfig
    { LoadBalancingConfig = { new RoundRobinConfig() };
  }
});
```

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

## References
[Build high-performance services with gRPC](https://medium.com/swlh/build-high-performance-services-with-grpc-and-net-5-7605ffe9b2a2)