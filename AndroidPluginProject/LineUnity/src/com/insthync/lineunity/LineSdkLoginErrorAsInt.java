package com.insthync.lineunity;

import jp.line.android.sdk.exception.LineSdkLoginError;

public class LineSdkLoginErrorAsInt
{
	public static final int FAILED_START_LOGIN_ACTIVITY = 0;
	public static final int FAILED_A2A_LOGIN = 1;
	public static final int FAILED_WEB_LOGIN = 2;
	public static final int UNKNOWN = 3;
	
	public static int FromEnum(LineSdkLoginError error)
	{
	    switch(error)
	    {
	        case FAILED_START_LOGIN_ACTIVITY:
	        	return LineSdkLoginErrorAsInt.FAILED_START_LOGIN_ACTIVITY;
	        case FAILED_A2A_LOGIN:
	        	return LineSdkLoginErrorAsInt.FAILED_A2A_LOGIN;
	        case FAILED_WEB_LOGIN:
	        	return LineSdkLoginErrorAsInt.FAILED_WEB_LOGIN;
	        default:
	        	return LineSdkLoginErrorAsInt.UNKNOWN;
	    }
	}

    public static LineSdkLoginError ToEnum(int value)
    {
        switch (value)
        {
            case FAILED_START_LOGIN_ACTIVITY:
                return LineSdkLoginError.FAILED_START_LOGIN_ACTIVITY;
            case FAILED_A2A_LOGIN:
                return LineSdkLoginError.FAILED_A2A_LOGIN;
            case FAILED_WEB_LOGIN:
                return LineSdkLoginError.FAILED_WEB_LOGIN;
            default:
                return LineSdkLoginError.UNKNOWN;
        }
    }
}
