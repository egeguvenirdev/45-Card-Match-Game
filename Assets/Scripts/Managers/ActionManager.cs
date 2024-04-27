using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public static class ActionManager
{
    //Game Actions
    public static Action GameStart { get; set; }
    public static Action<bool> GameEnd { get; set; }
    public static Action<float> Updater { get; set; }
    public static Action<AudioClip> PlaySound { get; set; }

    //Visual Effects
    public static Action CamShake { get; set; }
    public static Func<Vector3, Vector3> GetOrtograficScreenToWorldPoint { get; set; }
}
