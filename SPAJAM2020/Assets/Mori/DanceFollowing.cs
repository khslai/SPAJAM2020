using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DanceFollowing : MonoBehaviour
{

    public GameManager gameManager;
    public float FollowingTime;//DanceTimeから自動で設定
    public float followingdelta = 1.0f;

    public void DoInitialize()
    {
    }

    public void DoUpdate()
    {
        Debug.Log("FollowingDoUpDate");

        GameManager.Instance.RespawnNote();

        // タップしたらノーツ再生
        //InputManager.Instance.ButtonDownFollowing();
        InputManager.Instance.ButtonDown(0f);

        //各ノードを生成するタイミングの制御
        //if (RespawnNotesList.Count != 0 && GameManager.Instance.timer >= RespawnNotesList[0].SpawnTime - respawnTimeOffset)
        //{
        //    RespawnNotesList[0].ObjectMirror(respawnTimeOffset);
        //    RespawnNotesList.RemoveAt(0);
        //    Debug.Log("FollowingReMoveAt");
        //}

        //時間によるシーン遷移
        // timerが初期化されないから、Waitフェイスの時間も一緒に加算
        if (gameManager.timer > FollowingTime + gameManager.Wait.WaitTime)
        {
            gameManager.ChangePhase(GameManager.GamePhase.Waiting);
            gameManager.Wait.nextnextphase = GameManager.GamePhase.Leading;

            Debug.Log("FollowingOverTime");
        }
    }
}
