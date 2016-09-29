using Com.Insthync.LinePlugin;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LineDemo : MonoBehaviour {
    public UnityLinePlugin plugin;
    public Text messageText;


    public void Init()
    {
        plugin.Init();
        plugin.onLoginSuccess = (token) =>
        {
            messageText.text = "Login Success mid: " + token.mid + " accessToken: " + token.accessToken;
        };
        plugin.onLoginCanceled = () =>
        {
            messageText.text = "Login Canceled";
        };
        plugin.onLoginError = (error) =>
        {
            messageText.text = "Login Error: " + error; 
        };
        plugin.onApiError = (error) =>
        {
            messageText.text = "Api Error: " + error;
        };
        plugin.onAccessTokenReceived = (token) =>
        {
            messageText.text = "Access Token Received mid: " + token.mid + " accessToken: " + token.accessToken;
        };
        plugin.onMyProfileReceived = (profile) =>
        {
            messageText.text = "My Profile Received mid: " + profile.mid + " displayName: " + profile.displayName + " pictureUrl: " + profile.pictureUrl;
        };
    }
}
