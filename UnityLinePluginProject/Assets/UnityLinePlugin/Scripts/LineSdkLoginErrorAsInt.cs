namespace Com.Insthync.LinePlugin
{
    public class LineSdkLoginErrorAsInt
    {
        public const int FAILED_START_LOGIN_ACTIVITY = 0;
        public const int FAILED_A2A_LOGIN = 1;
        public const int FAILED_WEB_LOGIN = 2;
        public const int UNKNOWN = 3;

        public static int FromEnum(LineSdkLoginError error)
        {
            switch (error)
            {
                case LineSdkLoginError.FAILED_START_LOGIN_ACTIVITY:
                    return FAILED_START_LOGIN_ACTIVITY;
                case LineSdkLoginError.FAILED_A2A_LOGIN:
                    return FAILED_A2A_LOGIN;
                case LineSdkLoginError.FAILED_WEB_LOGIN:
                    return FAILED_WEB_LOGIN;
                default:
                    return UNKNOWN;
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
}
