using UnityEngine;

namespace Com.Suriyun.LinePlugin
{
    public class AndroidLinePluginHandler : ILinePluginHandler
    {
        AndroidJavaObject pluginObject;

        public void Init(string gameObjectName, string channelId)
        {
            pluginObject = new AndroidJavaObject("com.suriyun.lineunity.LineUnityPlugin");
            pluginObject.Call("init", gameObjectName, channelId);
            Debug.Log("Init() called");
        }

        public void LoginAutomatically()
        {
            pluginObject.Call("loginAutomatically");
            Debug.Log("LoginAutomatically() called");
        }

        public void LoginManually()
        {
            pluginObject.Call("loginManually");
            Debug.Log("LoginAutomatically() called");
        }

        public void Logout()
        {
            pluginObject.Call("logout");
            Debug.Log("Logout() called");
        }

        public void VerifyToken()
        {
            pluginObject.Call("verifyToken");
            Debug.Log("VerifyToken() called");
        }

        public void GetCurrentAccessToken()
        {
            pluginObject.Call("getCurrentAccessToken");
            Debug.Log("GetCurrentAccessToken() called");
        }

        public void RefreshToken()
        {
            pluginObject.Call("refreshToken");
            Debug.Log("RefreshToken() called");
        }

        public void GetProfile()
        {
            pluginObject.Call("getProfile");
            Debug.Log("GetProfile() called");
        }
    }
}
