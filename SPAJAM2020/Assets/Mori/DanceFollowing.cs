using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class DanceFollowing : MonoBehaviour
{

    public GameManager gameManager;
    public float FollowingTime;//DanceTimeから自動で設定
    public float followingdelta = 1.0f;
    public Animator Gradient_animator;
    public SpriteRenderer Gradient_sprite;
    public Color Gardient_default;
    public Color Gardient_dark;

    public int Note_count;
    public int Hit_count;
    private bool finished;
    
    public void DoInitialize()
    {
        Gradient_animator.SetTrigger("Trigger");
        Gradient_sprite.DOColor(Gardient_default,0.1f);
        Hit_count = 0;
        finished = false;
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
            //もし目標点数をクリアしていたらFinalPhaseに
            if(ScoreManager.Instance.Score >= ScoreManager.Instance.ClearScore)
            {

                gameManager.ChangePhase(GameManager.GamePhase.Waiting);
                gameManager.Wait.nextnextphase = GameManager.GamePhase.Final;

            }
            else
            {
                //そうでなければLeading
                gameManager.ChangePhase(GameManager.GamePhase.Waiting);
                gameManager.Wait.nextnextphase = GameManager.GamePhase.Leading;

            }


            Debug.Log("FollowingOverTime");
        }
    }

    public void HitNote()
    {
        Hit_count++;
        if(finished == false)
        {
            if(Hit_count >= Note_count)
            {
                Gradient_sprite.DOColor(Gardient_dark,1);
                finished = true;
            }
        }
    }
}
