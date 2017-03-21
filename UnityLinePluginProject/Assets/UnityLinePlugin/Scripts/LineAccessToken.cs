namespace Com.Suriyun.LinePlugin
{
    [System.Serializable]
    public class LineAccessToken
    {
        public string accessToken;
        public long getEstimatedExpirationTimeMillis;
        public long getExpiresInMillis;
        public long getIssuedClientTimeMillis;
    }
}
