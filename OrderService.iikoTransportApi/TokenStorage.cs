namespace OrderService.iikoTransportApi
{
    public class TokenStorage
    {
        private string _token;
        private DateTime _expires;
        private string _apiKey;

        public TokenStorage(string apiLogin)
        {
            _expires = DateTime.Now + TimeSpan.FromMinutes(20);
            _token = null;
            _apiKey = apiLogin;
        }

        public string Token { get { return _token; } }

        public string ApiKey { get { return _apiKey; } }

        public async Task<string> GetToken(iikoTransportClient client)
        {
            if (_token == null || DateTime.Now >= _expires)
            {
                var token = await client.GetAccessTokenAsync();
                _token = token.Token;
                _expires = DateTime.Now + TimeSpan.FromMinutes(20);
            }

            return _token;
        }
    }
}
