using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : ButtonBase
{
    public override void OnButtonClick()
    {
        base.OnButtonClick();
        ActionManager.StartButton?.Invoke();
    }
}
