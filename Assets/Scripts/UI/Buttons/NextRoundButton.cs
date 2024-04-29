using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoundButton : ButtonBase
{
    public override void OnButtonClick()
    {
        base.OnButtonClick();
        GameUIManager.Instance.OnRoundStart();
    }
}
