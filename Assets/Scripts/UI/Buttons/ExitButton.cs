using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : ButtonBase
{
    public override void OnButtonClick()
    {
        base.OnButtonClick();
        GameManager.Instance.FinishTheGame();
    }
}
