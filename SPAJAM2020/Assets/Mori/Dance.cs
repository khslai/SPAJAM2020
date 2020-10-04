﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class notesData
{
    public Vector2 pos;
    public float time;
}

public class Dance : MonoBehaviour
{
    public GameManager gameManager;
    public float DanceTime;
    /// <summary>
    /// ステートが始まってからの時間
    /// </summary>
    //public float timer = 0;

    public void DoInitialize()
    {
        //timer = 0;
    }

    public void DoUpdate()
    {

        //timer += Time.deltaTime;

        // タップしたらノーツ再生
        InputManager.Instance.ButtonDown(GameManager.Instance.timer);

        //時間によるシーン遷移
        if (gameManager.timer > DanceTime )
        {
            //現在の時間をDanceFollowingに代入 (+補正値を追加)
            gameManager.DanceFollowing.FollowingTime = gameManager.timer + gameManager.DanceFollowing.followingdelta;
            gameManager.ChangePhase(GameManager.GamePhase.Waiting);
            gameManager.Wait.nextnextphase = GameManager.GamePhase.Following;
        }
        //タップ回数によるシーン遷移
        if(gameManager.DanceFollowing.RespawnNotesList.Count >= ScoreManager.Instance.NowMaxNode_N)
        {
            //現在の時間をDanceFollowingに代入 (+補正値を追加)
            gameManager.DanceFollowing.FollowingTime = gameManager.timer + gameManager.DanceFollowing.followingdelta;
            gameManager.ChangePhase(GameManager.GamePhase.Waiting);
            gameManager.Wait.nextnextphase = GameManager.GamePhase.Following;
        }

    }

    public void DoUninit()
    {
    }
}
