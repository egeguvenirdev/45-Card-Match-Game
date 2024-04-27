using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCountInputButton : ButtonBase
{
    [SerializeField] private RoundCounter counter;
    [SerializeField] private int value = -1;
    public override void OnButtonClick()
    {
        counter.SetValue(value);
    }
}
