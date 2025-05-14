using System.Text.Json;
using Confluent.Kafka;

namespace AuthenticationService.Service {
    public class KafkaProducerService {
        private readonly IProducer<string, string> _producer;
        private const string Topic = "user-registered";

        public KafkaProducerService() {
            var config = new ProducerConfig{
                BootstrapServers = "localhost:9092"
            };

            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        // viết hàm để send event tới Kafka message broker
        public async Task PublishUserRegisteredEvent(string email, string username) {
            // define new message
            var message = new {
                Email = email,
                Username = username,
                Timestamp = DateTime.UtcNow
            };

            // convert về dạng JSON
            var jsonMessage = JsonSerializer.Serialize(message);

            // gửi message tới Kafka
            await _producer.ProduceAsync(Topic, new Message<string, string>{
                Key = email,
                Value = jsonMessage
            });
        }

        // viết hàm để close producer, clear bộ nhớ
        public void Dispose() {
            _producer.Dispose();
        }
    }
}