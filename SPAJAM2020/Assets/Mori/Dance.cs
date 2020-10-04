using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class notesData
{
    public Vector2 pos;
    public float time;
}

public class Dance : MonoBehaviour
{
    [SerializeField] Gradation gradation = null;

    public GameManager gameManager;
    public float DanceTime;
    /// <summary>
    /// ステートが始まってからの時間
    /// </summary>

    public void DoInitialize()
    {
        //timer = 0;
        gradation.PlayPhaseStartAnim();
    }

    public void DoUpdate()
    {
        //GameManager.Instance.RespawnNote();

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
        //if(gameManager.RespawnNotesList.Count >= ScoreManager.Instance.NowMaxNode_N)
        //{
        //    //現在の時間をDanceFollowingに代入 (+補正値を追加)
        //    gameManager.DanceFollowing.FollowingTime = gameManager.timer + gameManager.DanceFollowing.followingdelta;
        //    gameManager.ChangePhase(GameManager.GamePhase.Waiting);
        //    gameManager.Wait.nextnextphase = GameManager.GamePhase.Following;
        //}

    }

    public void DoUninit()
    {
    }
}
