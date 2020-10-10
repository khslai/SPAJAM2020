using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class notesData
{
    public Vector2 pos;
    public float time;
}

public class Dance : MonoBehaviour
{
    //[SerializeField] Gradation gradation = null;

    public GameManager gameManager;
    public float DanceTime;

    public Animator Gradient_animator;
    public SpriteRenderer Gradient_sprite;
    public Color Gardient_default;
    public Color Gardient_dark;
    /// <summary>
    /// ステートが始まってからの時間
    /// </summary>

    public void DoInitialize()
    {
        //timer = 0;
        //gradation.PlayPhaseStartAnim();
        Gradient_animator.SetTrigger("Trigger");
        Gradient_sprite.DOColor(Gardient_default,0.1f);
    }

    public void DoUpdate()
    {
        
        // タップしたらノーツ再生
        if (gameManager.RespawnNotesList.Count < ScoreManager.Instance.NowMaxNode_N)
        {


            InputManager.Instance.ButtonDown(GameManager.Instance.timer);

        }

        //時間によるシーン遷移
        if (gameManager.timer > DanceTime )
        {
            //現在の時間をDanceFollowingに代入 (+補正値を追加)
            gameManager.DanceFollowing.FollowingTime = gameManager.timer + gameManager.DanceFollowing.followingdelta;
            gameManager.ChangePhase(GameManager.GamePhase.Waiting);
            gameManager.Wait.nextnextphase = GameManager.GamePhase.Following;
        }

        //Update gradient color
        if(gameManager.RespawnNotesList.Count >= ScoreManager.Instance.NowMaxNode_N)
        {
            Gradient_sprite.DOColor(Gardient_dark,1);
        }
        else
        {
            Gradient_sprite.DOColor(Gardient_default,0.1f);
        }

        //タップ回数によるシーン遷移
        /*
        if(gameManager.RespawnNotesList.Count >= ScoreManager.Instance.NowMaxNode_N)
        {
            //現在の時間をDanceFollowingに代入 (+補正値を追加)
            gameManager.DanceFollowing.FollowingTime = gameManager.timer + gameManager.DanceFollowing.followingdelta;
            gameManager.ChangePhase(GameManager.GamePhase.Waiting);
            gameManager.Wait.nextnextphase = GameManager.GamePhase.Following;
        }
        */
    }

    public void DoUninit()
    {
    }
}
