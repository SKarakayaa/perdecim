
using StackExchange.Redis;

namespace Business.Concrete
{
    public class RedisManager
    {
        private readonly string _host;
        private readonly int _port;
        private ConnectionMultiplexer _connectionMultiplexer;
        public RedisManager(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(db);
    }
}