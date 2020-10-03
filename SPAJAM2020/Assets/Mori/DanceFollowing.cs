using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DanceFollowing : MonoBehaviour
{
    public List<Note> RespawnNotesList { get; private set; } = new List<Note>();

    public GameManager gameManager;
    public float FollowingTime;//DanceTimeから自動で設定
    public float followingdelta = 1.0f;

    public void DoInitialize()
    {

    }

    public void DoUpdate()
    {
        // タップしたらノーツ再生
        //InputManager.Instance.ButtonDownFollowing();
        InputManager.Instance.ButtonDown(0);

        //timer += Time.deltaTime;

        //各ノードを生成するタイミングの制御
        if (RespawnNotesList.Count != 0 && GameManager.Instance.timer >= RespawnNotesList[0].SpawnTime)
        {
            RespawnNotesList[0].ObjectMirror();
            RespawnNotesList.RemoveAt(0);
        }

        //時間によるシーン遷移
        if (gameManager.timer > FollowingTime)
        {
            gameManager.ChangePhase(GameManager.GamePhase.Waiting);
            gameManager.Wait.nextnextphase = GameManager.GamePhase.Leading;

        }

    }

    public void DoUninit()
    {
        RespawnNotesList.Clear();
    }
}
