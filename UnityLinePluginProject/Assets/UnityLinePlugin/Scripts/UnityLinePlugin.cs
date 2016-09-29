using UnityEngine;

namespace Com.Insthync.LinePlugin
{
    public enum LineSdkApiError
    {
        NOT_FOUND_ACCESS_TOKEN,
        SERVER_ERROR,
        ILLEGAL_RESPONSE,
        UNKNOWN
    }

    public enum LineSdkLoginError
    {
        FAILED_START_LOGIN_ACTIVITY,
        FAILED_A2A_LOGIN,
        FAILED_WEB_LOGIN,
        UNKNOWN
    }

    public class UnityLinePlugin : MonoBehaviour
    {
        public ILinePluginHandler Handler { get; protected set; }
        public bool IsInit { get; protected set; }
        public System.Action<LineAccessToken> onLoginSuccess;
        public System.Action onLoginCanceled;
        public System.Action<LineSdkLoginError> onLoginError;
        public System.Action<LineSdkApiError> onApiError;
        public System.Action<LineAccessToken> onAccessTokenReceived;
        public System.Action<LineProfile> onMyProfileReceived;

        protected virtual void Awake()
        {
            // TODO: Create handler for iOS later.
#if UNITY_ANDROID
            Handler = new AndroidLinePluginHandler();
#endif
            IsInit = false;
        }

        public void Init()
        {
            if (IsInit)
                return;

            if (Handler != null)
            {
                IsInit = true;
                Handler.Init(name);
            }
        }

        public void Login()
        {
            if (!IsInit)
                return;
            Handler.Login();
        }

        public void Logout()
        {
            if (!IsInit)
                return;
            Handler.Logout();
        }

        public void GetMyProfile()
        {
            if (!IsInit)
                return;
            Handler.GetMyProfile();
        }

        public virtual void OnMessageLoginSuccess(string json)
        {
            LineAccessToken accessToken = JsonUtility.FromJson<LineAccessToken>(json);
            if (onLoginSuccess != null)
                onLoginSuccess(accessToken);
        }

        public virtual void OnMessageLoginCanceled(string json)
        {
            if (onLoginCanceled != null)
                onLoginCanceled();
        }

        public virtual void OnMessageLoginError(string json)
        {
            LineError error = JsonUtility.FromJson<LineError>(json);
            LineSdkLoginError loginError = LineSdkLoginErrorAsInt.ToEnum(error.error);
            if (onLoginError != null)
                onLoginError(loginError);
        }

        public virtual void OnMessageApiError(string json)
        {
            LineError error = JsonUtility.FromJson<LineError>(json);
            LineSdkApiError apiError = LineSdkApiErrorAsInt.ToEnum(error.error);
            if (onApiError != null)
                onApiError(apiError);
        }

        public virtual void OnMessageAccessTokenReceived(string json)
        {
            LineAccessToken accessToken = JsonUtility.FromJson<LineAccessToken>(json);
            if (onAccessTokenReceived != null)
                onAccessTokenReceived(accessToken);
        }

        public virtual void OnMessageMyProfileReceived(string json)
        {
            LineProfile profile = JsonUtility.FromJson<LineProfile>(json);
            if (onMyProfileReceived != null)
                onMyProfileReceived(profile);
        }
    }
}
