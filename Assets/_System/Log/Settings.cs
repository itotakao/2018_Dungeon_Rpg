using Ito.Log;
using Ito.Setting;

public partial class Settings
{
    public class Log
    {
        public static readonly SettingEnum<LogLevels> LogLevel = new SettingEnum<LogLevels>("ログレベル", LogLevels.Log);
    }
}
