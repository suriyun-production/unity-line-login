namespace Com.Suriyun.LinePlugin
{
    public interface ILinePluginHandler
    {
        void Init(string gameObjectName, string channelId);
        void Login();
        void LoginWebView();
        void Logout();
        void VerifyToken();
        void GetCurrentAccessToken();
        void RefreshToken();
        void GetProfile();
    }
}
