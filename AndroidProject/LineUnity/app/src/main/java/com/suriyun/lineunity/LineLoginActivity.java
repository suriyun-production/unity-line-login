package com.suriyun.lineunity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;

import com.linecorp.linesdk.auth.LineLoginApi;
import com.linecorp.linesdk.auth.LineLoginResult;

public class LineLoginActivity extends Activity {
    public static final String EXTRA_CHANNEL_ID = "CHANNEL_ID";
    public static final String EXTRA_LOGIN_TYPE = "LOGIN_TYPE";
    public static final int LOGIN_TYPE_AUTO = 0;
    public static final int LOGIN_TYPE_MANUAL = 1;
    public static final int LOGIN_REQUEST_CODE = 101;

    protected String channelId;
    protected int loginType;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            channelId = extras.getString(EXTRA_CHANNEL_ID);
            loginType = extras.getInt(EXTRA_LOGIN_TYPE);
            Login();
        }
    }

    public void Login() {
        Intent loginIntent = null;
        switch (loginType) {
            case LOGIN_TYPE_AUTO:
                loginIntent = LineLoginApi.getLoginIntent(this, channelId);
                break;
            case LOGIN_TYPE_MANUAL:
                loginIntent = LineLoginApi.getLoginIntentWithoutLineAppAuth(this, channelId);
                break;
        }

        if (loginIntent != null)
        {
            startActivityForResult(loginIntent, LOGIN_REQUEST_CODE);
        }
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == LOGIN_REQUEST_CODE) {
            LineUnityPlugin.getInstance().validateLoginResult(LineLoginApi.getLoginResultFromIntent(data));
        }
    }
}
