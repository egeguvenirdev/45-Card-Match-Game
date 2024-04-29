using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public static class ActionManager
{
    //Game Actions
    public static Action GameStart { get; set; }
    public static Action RoundStart { get; set; }
    public static Action GameEnd { get; set; }
    public static Action<float> Updater { get; set; }
    public static Action<AudioClip> PlaySound { get; set; }

    //Card Actions
    public static Action<CardBase, int> CardSelection { get; set; }
    public static Action<int> TrueSelection { get; set; }
    public static Action GivePoints { get; set; }
    public static Action ReduceCardCount { get; set; }
    public static Action FalseSelection { get; set; }
    public static Action PlayQueueChange { get; set; }

    //Panel Actions
    public static Action CancelButton { get; set; }
    public static Action SettingsButton { get; set; }

    //Visual Effects
    public static Action CamShake { get; set; }
    public static Func<Vector3, Vector3> GetOrtograficScreenToWorldPoint { get; set; }
}
