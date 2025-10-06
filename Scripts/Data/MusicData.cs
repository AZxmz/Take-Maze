using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サウンドエフェクトデータクラスは、音楽設定に関連する情報を保存するために使用されます。
/// </summary>
public class MusicData
{
    public bool isOnMusic;
    public bool isOnSound;
    public float musicValue;
    public float soundValue;

    // デフォルトのデータはゲームに初めて参加した時のものではない
    public bool isNotFirst;
}
