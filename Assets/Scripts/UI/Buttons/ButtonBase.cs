using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonBase : MonoBehaviour
{
    protected VibrationManager vibration;

    protected virtual void Start()
    {
        vibration = VibrationManager.Instance;
    }

    public virtual void OnButtonClick()
    {
        vibration.SelectionVibration();
    }
}
