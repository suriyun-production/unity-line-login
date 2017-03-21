using System.Collections.Generic;

namespace Com.Suriyun.LinePlugin
{
    [System.Serializable]
    public class LineCredential
    {
        public LineAccessToken accessToken;
        public List<string> permission;
    }
}

