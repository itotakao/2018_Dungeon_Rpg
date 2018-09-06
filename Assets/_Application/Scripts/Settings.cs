using Ito.Setting;

public partial class Settings
{
    public class Debug
    {
        public static readonly SettingBool UseDebugKickCommand = new SettingBool("デバッグ用キック機能を使うか", true);
        public static readonly SettingBool UseDebugTimeCommand = new SettingBool("デバッグ用時間操作機能を使うか", true);
        public static readonly SettingBool UseDebugSkipCommand = new SettingBool("デバッグ用スキップ機能を使うか", true);
    }
}