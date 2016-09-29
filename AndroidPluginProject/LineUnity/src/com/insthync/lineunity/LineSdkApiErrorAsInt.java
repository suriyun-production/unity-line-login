package com.insthync.lineunity;

import jp.line.android.sdk.exception.LineSdkApiError;

public class LineSdkApiErrorAsInt
{
	public static final int NOT_FOUND_ACCESS_TOKEN = 0;
	public static final int SERVER_ERROR = 1;
	public static final int ILLEGAL_RESPONSE = 2;
	public static final int UNKNOWN = 3;

	public static int FromEnum(LineSdkApiError error)
	{
		switch(error)
		{
			case NOT_FOUND_ACCESS_TOKEN:
				return LineSdkApiErrorAsInt.NOT_FOUND_ACCESS_TOKEN;
			case SERVER_ERROR:
				return LineSdkApiErrorAsInt.SERVER_ERROR;
			case ILLEGAL_RESPONSE:
				return LineSdkApiErrorAsInt.ILLEGAL_RESPONSE;
			default:
				return LineSdkApiErrorAsInt.UNKNOWN;
		}
	}

    public static LineSdkApiError ToEnum(int value)
    {
        switch (value)
        {
            case NOT_FOUND_ACCESS_TOKEN:
                return LineSdkApiError.NOT_FOUND_ACCESS_TOKEN;
            case SERVER_ERROR:
                return LineSdkApiError.SERVER_ERROR;
            case ILLEGAL_RESPONSE:
                return LineSdkApiError.ILLEGAL_RESPONSE;
            default:
                return LineSdkApiError.UNKNOWN;
        }
    }
}
