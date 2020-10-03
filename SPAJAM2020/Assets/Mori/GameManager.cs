using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private Dance Dance;
    [SerializeField] private DanceFollowing DanceFollowing;

    //ゲームの状態を表す変数
    public enum Phase { 
        Leading = 0,
        Waiting = 1,
        Following = 2,
        //Waitingなど演出フェーズがある場合、追加してよい
        Title = 3,
        Final = 4
    }


    public Phase phase;// = Phase.Leading;

    // Start is called before the first frame update
    void Start()
    {
        //ダンスを生成
        Debug.Log("PlayerStart DanceLeading");


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Danceを生成する
            TogglePhase();
        }
        //α..フェーズごとに既定の数の音数を打ったら or 時間経過

        //
        switch (phase) {
            case Phase.Leading:
                Dance.DoUpdate();
                break;
            case Phase.Following:
                DanceFollowing.DoUpdate();
                break;

        }


    }

    //デバッグ用にキー入力でフェーズを入れ替えられるように
    void TogglePhase()
    {
        //プロトの仕様. 0と 1を交互に行う

        if(phase == Phase.Leading)
        {
            phase = Phase.Following;
            Debug.Log("PlayerStart DanceFollowing");
            DanceFollowing.DoInitialize();

        }
        else if (phase == Phase.Following)
        {
            phase = Phase.Leading;
            Debug.Log("PlayerStart DanceLeading");
            Dance.DoInitialize();
        }
    }

    //Danceを生成する関数
    private void MakeDance()
    {
        Debug.Log("PlayerStart DanceLeading");
    }

}
