using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Voider_Crew;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public partial class Plugin : BaseUnityPlugin
{
    public static ManualLogSource? StaticLogger { get; private set; }

    private static readonly Harmony _harmony = new(MyPluginInfo.PLUGIN_GUID);

    protected static int NewMaxPlayers { get; private set; } = 8;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members")]
    private void Awake()
    {
        StaticLogger = this.Logger;
        this.Logger.LogDebug($"Plugin {MyPluginInfo.PLUGIN_GUID} is loading!");
        try
        {
            _harmony.PatchAll();
        }
        catch (HarmonyException ex)
        {
            this.Logger.LogError(ex.Message);
            this.Logger.LogError($"Plugin {MyPluginInfo.PLUGIN_GUID} failed to patch!");
            return;
        }
        this.Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }
}
