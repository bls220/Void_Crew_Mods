using HarmonyLib;
using System.Linq;
using UnityEngine.UIElements;

namespace Voider_Crew;

public partial class Plugin
{
    [HarmonyPatch(typeof(MatchmakingRoomSetup))]
    private static class MatchmakingRoomSetupPatch
    {
        [HarmonyPostfix, HarmonyPatch(MethodType.Constructor, typeof(VisualElement))]
        private static void Constructor_Postfix(VisualElement root, SliderInt ___playerLimitInput)
        {
            ___playerLimitInput.highValue = Plugin.NewMaxPlayers;
            ___playerLimitInput.RegisterValueChangedCallback((evt) =>
            {
                // Last Label within slider is the "max" label.
                // I have to select it positionally since it has no unique name or CSS class.
                if (___playerLimitInput.Children().Last() is Label label)
                {
                    label.text = evt.newValue.ToString();
                }
            });
        }
    }
}
