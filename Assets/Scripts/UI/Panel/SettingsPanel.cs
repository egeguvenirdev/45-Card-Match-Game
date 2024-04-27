using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : PanelBase
{
    public override void Init()
    {
        ActionManager.SettingsButton += OpenPanelElements;
        ActionManager.CancelButton += ClosePanelElements;
    }

    public override void DeInit()
    {
        ActionManager.SettingsButton -= OpenPanelElements;
        ActionManager.CancelButton -= ClosePanelElements;
    }
}
