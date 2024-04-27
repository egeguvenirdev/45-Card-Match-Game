using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : ButtonBase
{
    public override void OnButtonClick()
    {
        base.OnButtonClick();
        ActionManager.SettingsButton?.Invoke();
    }
}
