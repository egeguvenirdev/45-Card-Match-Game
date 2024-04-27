using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerInputButton : ButtonBase
{
    [SerializeField] private RoundTimer timer;
    [SerializeField] private int value = -1;
    public override void OnButtonClick()
    {
        timer.SetValue(value);
    }
}
