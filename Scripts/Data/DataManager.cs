using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームデータ管理
/// </summary>
public class DataManager
{
    private static DataManager instance = new DataManager();
    public static DataManager Instance
    {
        get { return instance; }
    }

    public MusicData musicData;
    public RankDataList rankDatas;

    private DataManager()
    {
        musicData = PlayerPrefsDataManager.Instance.LoadData(typeof(MusicData), "Music") as MusicData;
        
        if (!musicData.isNotFirst)
        {
            musicData.isNotFirst = true;
            musicData.isOnMusic = true;
            musicData.isOnSound = true;
            musicData.musicValue = 1;
            musicData.soundValue = 1;
            PlayerPrefsDataManager.Instance.SaveData(musicData, "Music");
            
        }
        rankDatas = PlayerPrefsDataManager.Instance.LoadData(typeof(RankDataList), "Rank") as RankDataList;
        

    }

   
    public void UpdateRankDate(string player, int score, float time)
    {
        rankDatas.list.Add(new RankData(player, score, time));
        rankDatas.list.Sort((a, b) => a.time < b.time ? -1 : 1);

        // 冗長データを削除する
        for (int i = rankDatas.list.Count - 1; i >= 8; i--)
        {
            rankDatas.list.RemoveAt(i);
        }

        PlayerPrefsDataManager.Instance.SaveData(rankDatas, "Rank");

    }

    
    public void MusicState(bool isOn)
    {
        musicData.isOnMusic = isOn;
        Music.Instance.ChangeState(isOn);
        PlayerPrefsDataManager.Instance.SaveData(musicData, "Music");
    }

   
    public void MusicValue(float value)
    {
        musicData.musicValue = value;
        Music.Instance.ChangeMusicValue(value);
        PlayerPrefsDataManager.Instance.SaveData(musicData, "Music");
    }

   
    public void SoundState(bool isOn)
    {
        musicData.isOnSound = isOn;
        PlayerPrefsDataManager.Instance.SaveData(musicData, "Music");
    }


    
    public void SoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsDataManager.Instance.SaveData(musicData, "Music");
    }


   
}
