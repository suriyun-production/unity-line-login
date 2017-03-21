namespace Com.Suriyun.LinePlugin
{
    [System.Serializable]
    public class LineError
    {
        public bool networkError;
        public bool serverError;
        public int httpResponseCode;
        public string message;
    }
}

