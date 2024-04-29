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
        [SerializeField] private int minGridSizeX = 4;
        [ShowOnly, SerializeField] private int gridSizeX = 4;
        [SerializeField] private int minGridSizeY = 4;
        [ShowOnly, SerializeField] private int gridSizeY = 4;

        [Header("Round Time (Min)")]
        [SerializeField] private int minTime = 1;
        [ShowOnly, SerializeField] private int time = 2;

        [Header("Round Count")]
        [SerializeField] private int minRoundCount = 1;
        [ShowOnly, SerializeField] private int roundCount = 3;

        public int GridSizeX
        {
            get => gridSizeX;
            set
            {
                gridSizeX = value;
                if (gridSizeX < minGridSizeX) gridSizeX = minGridSizeX;
            }
        }
        public int GridSizeY
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

