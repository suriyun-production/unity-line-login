namespace Com.Suriyun.LinePlugin
{
    public interface ILinePluginHandler
    {
        void Init(string gameObjectName, string channelId);
        void LoginAutomatically();
        void LoginManually();
        void Logout();
        void VerifyToken();
        void GetCurrentAccessToken();
        void RefreshToken();
        void GetProfile();
    }
}
