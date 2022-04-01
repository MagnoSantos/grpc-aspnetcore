using Grpc.Core;

namespace GRC.Sample.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Receive request");

            var reply = Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });

            _logger.LogInformation(@"{Reply} produces at {time}", reply, DateTime.Now);

            return reply;
        }
    }
}