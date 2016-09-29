namespace Com.Insthync.LinePlugin
{
    public class LineSdkApiErrorAsInt
    {
        public const int NOT_FOUND_ACCESS_TOKEN = 0;
        public const int SERVER_ERROR = 1;
        public const int ILLEGAL_RESPONSE = 2;
        public const int UNKNOWN = 3;

        public static int FromEnum(LineSdkApiError error)
        {
            switch (error)
            {
                case LineSdkApiError.NOT_FOUND_ACCESS_TOKEN:
                    return NOT_FOUND_ACCESS_TOKEN;
                case LineSdkApiError.SERVER_ERROR:
                    return SERVER_ERROR;
                case LineSdkApiError.ILLEGAL_RESPONSE:
                    return ILLEGAL_RESPONSE;
                default:
                    return UNKNOWN;
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
}
