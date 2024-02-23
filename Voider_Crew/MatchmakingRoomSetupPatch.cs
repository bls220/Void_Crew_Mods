using System.Reflection;

using HarmonyLib;

using UI.Settings;

using UnityEngine.UIElements;

namespace Voider_Crew;

public partial class Plugin
{
    [HarmonyPatch(typeof(MatchmakingRoomSetup))]
    private static class MatchmakingRoomSetupPatch
    {
        [HarmonyPostfix, HarmonyPatch(MethodType.Constructor, typeof(VisualElement))]
        private static void Constructor_Postfix(VisualElement root)
        {
            // Get the player setting slider
            var playerSlider = root.Q<SliderIntSettingEntryVE?>("PlayerSlider", (string?)null, (string?)null);
            if (playerSlider is null)
            {
                Plugin.StaticLogger?.LogError("Unable to find the PlayerSlider");
                return;
            }

            // Get the slider element
            if (typeof(SliderIntSettingEntryVE).GetField("slider", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(playerSlider) is not SliderInt playerLimitInput)
            {
                Plugin.StaticLogger?.LogError("Unable to find the PlayerSlider.slider");
                return;
            }
            // Set the HighValue to our Max Players
            playerLimitInput.highValue = Plugin.NewMaxPlayers;
            playerLimitInput.RegisterValueChangedCallback((evt) => Plugin.StaticLogger?.LogDebug($"Player limit slider changed to {evt.newValue}"));
        }
    }
}
