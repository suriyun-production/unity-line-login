using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Com.Suriyun.LinePlugin
{
    public class IOSLinePluginHandler : ILinePluginHandler
    {
        private IntPtr instance;

        public void Init(string gameObjectName, string channelId)
        {
            instance = _LineUnityPlugin_Init(gameObjectName, channelId);
            Debug.Log("Init() called");
        }

        public void Login()
        {
            _LineUnityPlugin_Login(instance);
            Debug.Log("Login() called");
        }

        public void LoginWebView()
        {
            _LineUnityPlugin_LoginWebView(instance);
            Debug.Log("LoginWebView() called");
        }

        public void Logout()
        {
            _LineUnityPlugin_Logout(instance);
            Debug.Log("Logout() called");
        }

        public void VerifyToken()
        {
            _LineUnityPlugin_VerifyToken(instance);
            Debug.Log("VerifyToken() called");
        }

        public void GetCurrentAccessToken()
        {
            _LineUnityPlugin_GetCurrentAccessToken(instance);
            Debug.Log("GetCurrentAccessToken() called");
        }

        public void RefreshToken()
        {
            _LineUnityPlugin_RefreshToken(instance);
            Debug.Log("RefreshToken() called");
        }

        public void GetProfile()
        {
            _LineUnityPlugin_GetProfile(instance);
            Debug.Log("GetProfile() called");
        }

        [DllImport("__Internal")]
        private static extern IntPtr _LineUnityPlugin_Init(string gameObjectName, string channelId);
        [DllImport("__Internal")]
        private static extern int _LineUnityPlugin_Login(IntPtr instance);
        [DllImport("__Internal")]
        private static extern int _LineUnityPlugin_LoginWebView(IntPtr instance);
        [DllImport("__Internal")]
        private static extern int _LineUnityPlugin_Logout(IntPtr instance);
        [DllImport("__Internal")]
        private static extern int _LineUnityPlugin_VerifyToken(IntPtr instance);
        [DllImport("__Internal")]
        private static extern int _LineUnityPlugin_GetCurrentAccessToken(IntPtr instance);
        [DllImport("__Internal")]
        private static extern int _LineUnityPlugin_RefreshToken(IntPtr instance);
        [DllImport("__Internal")]
        private static extern int _LineUnityPlugin_GetProfile(IntPtr instance);
    }
}