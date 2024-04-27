using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Game Infos", menuName = "Game Infos")]

public class GamePlayInfos : ScriptableObject
{
    [SerializeField] private GameInfos gameInfos;

    public GameInfos GetGameInfos { get => gameInfos; set => gameInfos = value; }

    [Serializable]
    public class GameInfos
    {
        [Header("Grid")]
        [SerializeField] private float minGridSizeX = 4;
        [ShowOnly, SerializeField] private float gridSizeX = 4;
        [SerializeField] private float minGridSizeY = 4;
        [ShowOnly, SerializeField] private float gridSizeY = 4;

        [Header("Round Time (Min)")]
        [SerializeField] private int minTime = 2;
        [ShowOnly, SerializeField] private int time = 2;

        [Header("Round Count")]
        [SerializeField] private int minRoundCount = 3;
        [ShowOnly, SerializeField] private int roundCount;

        public float GridSizeX
        {
            get => gridSizeX;
            set
            {
                gridSizeX = value;
                if (gridSizeX < minGridSizeX) gridSizeX = minGridSizeX;
            }
        }
        public float GridSizeY
        {
            get => gridSizeY;
            set
            {
                gridSizeY = value;
                if (gridSizeY < minGridSizeY) gridSizeY = minGridSizeY;
            }
        }
        public int Time
        {
            get => time;
            set
            {
                time += value;
                if (time < minTime) time = minTime;
            }
        }
        public int RoundCount
        {
            get => roundCount;
            set
            {
                roundCount += value;
                if (roundCount < minRoundCount) roundCount = minRoundCount;
            }
        }
    }
}

