using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ランキング管理データ関連
/// </summary>
public class RankData
{
    public string player;
    public int score;
    public float time;


    public RankData()
    {

    }
    public RankData(string player, int score, float time)
    {
        this.player = player;
        this.score = score;
        this.time = time;
    }
}

public class RankDataList
{
    public List<RankData> list = new List<RankData>();
}




