using BepInEx;
using HarmonyLib;

namespace SkipIntro;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public partial class Plugin : BaseUnityPlugin
{
    private static readonly Harmony _harmony = new(MyPluginInfo.PLUGIN_GUID);

    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members")]
    private void Awake()
    {
        this.Logger.LogDebug($"Plugin {MyPluginInfo.PLUGIN_GUID} is loading!");
        _harmony.PatchAll();
        this.Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }
}
