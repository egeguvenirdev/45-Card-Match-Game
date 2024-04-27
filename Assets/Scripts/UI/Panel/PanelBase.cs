using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PanelBase : MonoBehaviour
{
    [SerializeField] protected GameObject panelElements;

    public abstract void Init();

    public abstract void DeInit();

    protected virtual void OpenPanelElements()
    {
        panelElements.SetActive(true);
    }

    protected virtual void ClosePanelElements()
    {
        panelElements.SetActive(false);
    }
}
