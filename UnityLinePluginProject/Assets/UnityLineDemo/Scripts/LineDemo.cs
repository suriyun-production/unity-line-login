using Com.Suriyun.LinePlugin;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LineDemo : MonoBehaviour {
    public UnityLinePlugin plugin;
    public Text messageText;


    public void Init()
    {
        plugin.Init();
        plugin.onLoginSuccess = (login) =>
        {
            messageText.text = "Login Success userId: " + login.profile.userId + " accessToken: " + login.credential.accessToken;
        };
        plugin.onApiError = (error) =>
        {
            messageText.text = "Api Error: " + error;
        };
        plugin.onAccessTokenReceived = (token) =>
        {
            messageText.text = "Access Token Received accessToken: " + token.accessToken;
        };
        plugin.onProfileReceived = (profile) =>
        {
            messageText.text = "My Profile Received userId: " + profile.userId + " displayName: " + profile.displayName + " pictureUrl: " + profile.pictureUrl;
        };
    }
}
