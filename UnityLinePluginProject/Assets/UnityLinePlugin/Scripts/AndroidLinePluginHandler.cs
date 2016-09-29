using UnityEngine;

namespace Com.Insthync.LinePlugin
{
    public class AndroidLinePluginHandler : ILinePluginHandler
    {
        AndroidJavaObject pluginObject;

        public void Init(string gameObjectName)
        {
            pluginObject = new AndroidJavaObject("com.insthync.lineunity.LineUnityPlugin");
            pluginObject.Call("Init", gameObjectName);
            Debug.Log("Init() called");
        }

        public void Login()
        {
            pluginObject.Call("Login");
            Debug.Log("Login() called");
        }

        public void Logout()
        {
            pluginObject.Call("Logout");
            Debug.Log("Logout() called");
        }

        public void GetMyProfile()
        {
            pluginObject.Call("GetMyProfile");
            Debug.Log("GetMyProfile() called");
        }
    }
}
