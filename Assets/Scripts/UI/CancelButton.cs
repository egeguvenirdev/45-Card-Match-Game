using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : ButtonBase
{
    public override void OnButtonClick()
    {
        base.OnButtonClick();
        ActionManager.CancelButton?.Invoke();
    }
}
