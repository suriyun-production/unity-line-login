package com.insthync.lineunity;

import android.app.Activity;
import android.util.Log;
import com.unity3d.player.UnityPlayer;
import jp.line.android.sdk.LineSdkContext;
import jp.line.android.sdk.LineSdkContextManager;
import jp.line.android.sdk.api.ApiClient;
import jp.line.android.sdk.api.ApiRequestFuture;
import jp.line.android.sdk.api.ApiRequestFutureListener;
import jp.line.android.sdk.exception.LineSdkApiError;
import jp.line.android.sdk.exception.LineSdkApiException;
import jp.line.android.sdk.exception.LineSdkApiServerError;
import jp.line.android.sdk.exception.LineSdkLoginError;
import jp.line.android.sdk.exception.LineSdkLoginException;
import jp.line.android.sdk.login.LineAuthManager;
import jp.line.android.sdk.login.LineLoginFuture;
import jp.line.android.sdk.login.LineLoginFutureListener;
import jp.line.android.sdk.login.OnAccessTokenChangedListener;
import jp.line.android.sdk.model.AccessToken;
import jp.line.android.sdk.model.Profile;

public class LineUnityPlugin implements OnAccessTokenChangedListener
{
	public static final String TAG = "LineUnityPlugin";
	public static final String METHOD_LOGIN_SUCCUSS = "OnMessageLoginSuccess";
	public static final String METHOD_LOGIN_CANCELED = "OnMessageLoginCanceled";
	public static final String METHOD_LOGIN_ERROR = "OnMessageLoginError";
	public static final String METHOD_API_ERROR = "OnMessageApiError";
	public static final String METHOD_ACCESS_TOKEN_RECEIVED = "OnMessageAccessTokenReceived";
	public static final String METHOD_MY_PROFILE_RECEIVED = "OnMessageMyProfileReceived";
	
	private String gameObjectName = "";
	private boolean isInit = false;
	public void Init(String gameObjectName)
	{
		Log.d(TAG, "Init()");
		if (isInit)
		{
			Log.w(TAG, "Plugin has been initialized, Don't do it again!");
			return;
		}
		isInit = true;
		
		this.gameObjectName = gameObjectName;
		final Activity activity = UnityPlayer.currentActivity;
		LineSdkContextManager.initialize(activity.getApplicationContext());
	}
	
    @Override
    public void onAccessTokenChanged(final AccessToken accessToken)
    {
    	SendAccessTokenMessage(accessToken);
    }
	
	public boolean IsInit()
	{
		return isInit;
	}
	
	private boolean CheckInitToDoAction()
	{
		if (!isInit)
			Log.w(TAG, "Plugin does not initialized, Please do it!");
		return isInit;
	}
	
	public void Login()
	{
		Log.d(TAG, "Login()");
		if (!CheckInitToDoAction())
			return;

		final Activity activity = UnityPlayer.currentActivity;
		activity.runOnUiThread(new Runnable() {
			@Override
			public void run()
			{
				LineSdkContext sdkContext = LineSdkContextManager.getSdkContext();
				LineAuthManager authManager = sdkContext.getAuthManager();
				LineLoginFuture loginFuture = authManager.login(activity);
				loginFuture.addFutureListener(new LineLoginFutureListener() {
				    @Override
				    public void loginComplete(LineLoginFuture future)
				    {
				        switch(future.getProgress())
				        {
				            case SUCCESS:
				            	// Send message to unity behavior that it success
				            	SendLoginSuccessMessage(future.getAccessToken());
				            	LineSdkContext sdkContext = LineSdkContextManager.getSdkContext();
				            	LineAuthManager authManager = sdkContext.getAuthManager();
				            	authManager.removeOnAccessTokenChangedListener(LineUnityPlugin.this);
				            	authManager.addOnAccessTokenChangedListener(LineUnityPlugin.this);
				                break;
				            case CANCELED:
				            	// Send message to unity behavior that it cancelled
				            	SendLoginCanceledMessage();
				                break;
				            default:
				            	// Send message to unity behavior that it error occurred
				            	SendLoginErrorMessage(future.getCause());
				                break;
				        }
				    }
				});
			}
		});
	}
	
	public void Logout()
	{
		Log.d(TAG, "Logout()");
		if (!CheckInitToDoAction())
			return;

		final Activity activity = UnityPlayer.currentActivity;
		activity.runOnUiThread(new Runnable() {
			@Override
			public void run()
			{
				LineSdkContext sdkContext = LineSdkContextManager.getSdkContext();
				LineAuthManager authManager = sdkContext.getAuthManager();
				authManager.logout();
			}
		});
	}
	
	public void GetMyProfile()
	{
		Log.d(TAG, "GetMyProfile()");
		if (!CheckInitToDoAction())
			return;

		final Activity activity = UnityPlayer.currentActivity;
		activity.runOnUiThread(new Runnable() {
			@Override
			public void run()
			{
				LineSdkContext sdkContext = LineSdkContextManager.getSdkContext();
				ApiClient apiClient = sdkContext.getApiClient();
				apiClient.getMyProfile(new ApiRequestFutureListener<Profile>() {
				    @Override
				    public void requestComplete(ApiRequestFuture<Profile> future)
				    {
				        switch(future.getStatus())
				        {
				            case SUCCESS:
				                Profile profile = future.getResponseObject();
				                SendMyProfileMessage(profile);
				                break;
				            default:
				                // Failed to call API
				            	SendApiErrorMessage(future.getCause());
				                break;
				        }
				    }
				});
			}
		});
	}
	
	private void SendLoginSuccessMessage(AccessToken accessToken)
	{
		SendMessage(METHOD_LOGIN_SUCCUSS, AccessTokenToJson(accessToken));
	}
	
	private void SendLoginCanceledMessage()
	{
		SendMessage(METHOD_LOGIN_CANCELED, "[]");
	}
	
	private void SendLoginErrorMessage(Throwable cause)
	{
		int errorNum = LineSdkLoginErrorAsInt.UNKNOWN;
		if (cause instanceof LineSdkLoginException)
		{
			LineSdkLoginException loginException = (LineSdkLoginException)cause;
			LineSdkLoginError error = loginException.error;
			errorNum = LineSdkLoginErrorAsInt.FromEnum(error);
		}
		SendMessage(METHOD_LOGIN_ERROR, "{\"error\":" + errorNum + "}");
	}
	
	private void SendApiErrorMessage(Throwable cause)
	{
		int errorNum = LineSdkApiErrorAsInt.UNKNOWN;
		String serverErrorJson = "";
		if (cause instanceof LineSdkApiException)
		{
			LineSdkApiException apiException = (LineSdkApiException)cause;
			LineSdkApiError error = apiException.apiError;
			if (error == LineSdkApiError.SERVER_ERROR)
			{
				LineSdkApiServerError serverError = apiException.serverError;
				serverErrorJson = ",\"serverErrorCode\":" + serverError.statusCode + ",\"serverErrorMessage:\":\"" + serverError.statusMessage + "\"";
			}
			errorNum = LineSdkApiErrorAsInt.FromEnum(error);
		}
		SendMessage(METHOD_API_ERROR, "{\"error\":" + errorNum + serverErrorJson + "}");
	}
	
	private void SendAccessTokenMessage(AccessToken accessToken)
	{
		SendMessage(METHOD_ACCESS_TOKEN_RECEIVED, AccessTokenToJson(accessToken));
	}
	
	private void SendMyProfileMessage(Profile profile)
	{
		SendMessage(METHOD_MY_PROFILE_RECEIVED, ProfileToJson(profile));
	}
	
	private void SendMessage(String method, String json)
	{
    	UnityPlayer.UnitySendMessage(gameObjectName, method, json);	
	}
	
	public static String ProfileToJson(Profile profile)
	{
		return "{\"mid\":\"" + profile.mid + "\",\"displayName\":\"" + profile.displayName + "\",\"pictureUrl\":\"" + profile.pictureUrl + "\",\"statusMessage\":\"" + profile.statusMessage + "\"}";
	}
	
	public static String AccessTokenToJson(AccessToken accessToken)
	{
		return "{\"mid\":\"" + accessToken.mid + "\",\"accessToken\":\"" + accessToken.accessToken + "\"}";
	}
}
