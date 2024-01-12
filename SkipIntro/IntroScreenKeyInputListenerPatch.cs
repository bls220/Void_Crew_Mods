using CG.GameLoopStateMachine;
using CG.GameLoopStateMachine.GameStates;
using HarmonyLib;
using ToolClasses;

namespace SkipIntro;

[HarmonyPatch(typeof(IntroScreenKeyInputListener))]
static class IntroScreenKeyInputListenerPatch
{
    [HarmonyPostfix, HarmonyPatch("Update")]
    private static void Awake_Postfix()
    {
        (Singleton<GameStateMachine>.Instance.CurrentState as GSIntro)?.EndIntro();
    }
}
