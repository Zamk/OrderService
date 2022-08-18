namespace OrderService.iikoTransportApi
{
    public class TokenStorage
    {
        private string _token;
        private DateTime _expires;
        private string _apiKey;
        private int _tokenExpirationTime;

        /// <summary>
        /// Конструктор класса для хранения, получения и обновления токена.
        /// </summary>
        /// <param name="apiLogin">iikoTransport ApiLogin</param>
        /// <param name="tokenExpirationTime">Срок жизни токена, в минутах</param>
        public TokenStorage(string apiLogin, int tokenExpirationTime = 20)
        {
            _expires = DateTime.Now;
            _token = String.Empty;
            _apiKey = apiLogin;
            _tokenExpirationTime = tokenExpirationTime;
        }

        public string ApiKey { get { return _apiKey; } }

        /// <summary>
        /// Получает актуальный токен iikoTransport API
        /// </summary>
        /// <param name="client">Клиент, для для которого получем токен</param>
        /// <returns>String содержащий токен авторизации</returns>
        public async Task<string> GetToken(iikoTransportClient client)
        {
            if (_token == null || _token == String.Empty || DateTime.Now >= _expires)
            {
                var token = await client.GetAccessTokenAsync();
                _token = token.Token;
                _expires = DateTime.Now + TimeSpan.FromMinutes(_tokenExpirationTime);
            }

            return _token;
        }
    }
}
