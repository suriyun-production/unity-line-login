using System.Collections.Generic;

namespace Com.Suriyun.LinePlugin
{
    [System.Serializable]
    public class LineVerifyResult
    {
        public long expiresInMillis;
        public List<string> permission;
    }
}

