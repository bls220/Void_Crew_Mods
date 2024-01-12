using Gameplay.MissionDifficulty;
using HarmonyLib;

namespace Voider_Crew;

public partial class Plugin
{
    [HarmonyPatch(typeof(DifficultyPlayerCountTable))]
    private static class DifficultyPlayerCountTablePatch
    {
        [HarmonyPrefix, HarmonyPatch(nameof(DifficultyPlayerCountTable.GetConfig))]
        private static void CreateLobby_Prefix(ref int playerCount)
        {
            if (playerCount > 4)
            {
                playerCount = 4;
            }
        }
    }
}
