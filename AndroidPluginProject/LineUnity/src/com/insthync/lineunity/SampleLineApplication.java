package com.insthync.lineunity;

import android.app.Application;
import jp.line.android.sdk.LineSdkContextManager;

public class SampleLineApplication extends Application
{
	@Override
	public void onCreate()
	{
		super.onCreate();
		LineSdkContextManager.initialize(this);
	}
}
