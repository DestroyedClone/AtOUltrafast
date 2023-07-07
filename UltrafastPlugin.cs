using BepInEx;
using BepInEx.Configuration;

namespace AtOUltrafast
{
    [BepInPlugin("com.DestroyedClone.Ultrafast", "Ultrafast", "0.1.0")]
    public class AtOUltrafastPlugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> cfgCUltrafastRequiresFast;

        public void Start()
        {
            cfgCUltrafastRequiresFast = Config.Bind("", "Ultrafast Requires Fast", true, "If true, ultrafast will only be enabled if the game speed is already set to fast. If false, then it will always be enabled.");

            On.SettingsManager.LoadPrefs += SettingsManager_LoadPrefs;
        }

        private void SettingsManager_LoadPrefs(On.SettingsManager.orig_LoadPrefs orig, SettingsManager self)
        {
            orig(self);
            if (!cfgCUltrafastRequiresFast.Value || GameManager.Instance.configGameSpeed == Enums.ConfigSpeed.Fast)
            {
                GameManager.Instance.configGameSpeed = Enums.ConfigSpeed.Ultrafast;
            }
        }
    }
}