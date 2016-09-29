namespace Com.Insthync.LinePlugin
{
    public interface ILinePluginHandler
    {
        void Init(string gameObjectName);
        void Login();
        void Logout();
        void GetMyProfile();
    }
}
