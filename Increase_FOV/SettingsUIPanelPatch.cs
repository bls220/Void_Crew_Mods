using HarmonyLib;
using UI.Settings;
using UnityEngine.UIElements;

namespace Increase_FOV;

[HarmonyPatch(typeof(SettingsUIPanel))]
static class SettingsUIPanelPatch
{
    [HarmonyPostfix, HarmonyPatch("OnInitialize")]
    private static void OnInitialize_Postfix(UIDocument ____doc)
    {
        var graphicsPanel = ____doc.rootVisualElement.Q("GraphicsSettingsPanel");
        var fov = graphicsPanel.Q<SliderIntSettingEntryVE>("Fov");

        var settingInfo = AccessTools.Field(typeof(SliderIntSettingEntryVE), "setting");
        var setting = (IntSetting)settingInfo.GetValue(fov);

        var highValueInfo = AccessTools.PropertySetter(typeof(SliderIntSettingEntryVE), "HighValue");
        highValueInfo.Invoke(fov, [setting.MaxValue]);

        var sliderInfo = AccessTools.Field(typeof(SliderIntSettingEntryVE), "slider");
        var slider = (SliderInt)sliderInfo.GetValue(fov);

        slider.highValue = setting.MaxValue;

        fov.Reload();
    }
}
