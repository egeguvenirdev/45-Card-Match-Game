using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : PanelBase
{
    public override void Init()
    {
        ActionManager.SettingsButton += ClosePanelElements;
        ActionManager.CancelButton += OpenPanelElements;
    }

    public override void DeInit()
    {
        ActionManager.SettingsButton -= ClosePanelElements;
        ActionManager.CancelButton -= OpenPanelElements;
    }
}
