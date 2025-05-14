using System.Text.Json;
using Confluent.Kafka;

namespace EmailService.Services {
    public class KafkaConsumerService: BackgroundService {
        private readonly IConsumer<string, string> _consumer;
        private readonly IEmailService _emailService;
        private const string Topic = "user-registered";

        public KafkaConsumerService(IEmailService emailService) {
            // config consumer
            var config = new ConsumerConfig {
                BootstrapServers = "localhost:9092",
                GroupId = "email-service-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken){
            // subcribe topic
            _consumer.Subscribe(Topic);
            Console.WriteLine("Subscribed to topic: " + Topic);
            while (!stoppingToken.IsCancellationRequested) {
                try
                {
                    var consumeResult = _consumer.Consume(stoppingToken);

                    // convert JSON -> object
                    var message = JsonSerializer.Deserialize<UserRegistered>(consumeResult.Message.Value);
                    if(message != null) {
                        await _emailService.SendWelcomeEmail(message.Email, message.Username);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public override void Dispose()
        {
            _consumer?.Dispose();
            base.Dispose();
        }
    }

    public class UserRegistered {
        public required string Email {get; set;}
        public required string Username {get; set;}

        public DateTime Timestamp {get; set;}
    }
}