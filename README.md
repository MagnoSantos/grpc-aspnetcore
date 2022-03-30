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


<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

## References
[Build high-performance services with gRPC](https://medium.com/swlh/build-high-performance-services-with-grpc-and-net-5-7605ffe9b2a2)