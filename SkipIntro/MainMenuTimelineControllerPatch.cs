using HarmonyLib;

namespace SkipIntro;

[HarmonyPatch(typeof(MainMenuTimelineController))]
static class MainMenuTimelineControllerPatch
{
    [HarmonyPrefix, HarmonyPatch("Update")]
    private static void Update_Prefix(ref bool ____skipIntro)
    {
        ____skipIntro = true;
    }
}
