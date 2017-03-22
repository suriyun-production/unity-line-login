namespace Com.Suriyun.LinePlugin
{
    [System.Serializable]
    public class LineAccessToken
    {
        public string accessToken;
        public long estimatedExpirationTimeMillis;
        public long expiresInMillis;
    }
}
