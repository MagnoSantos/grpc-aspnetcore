using GRC.Sample;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Configuration;

namespace GRPC.Sample.Client.Services;

public class DefaultCallgRPCService
{
    public static async Task CallAsync()
    {
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

        var client = new Greeter.GreeterClient(channel);

        var reply = await client.SayHelloAsync(new HelloRequest { Name = "grpc demonstration" });

        Console.WriteLine(@"Reply: {reply}", reply);
    }
}