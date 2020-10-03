using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private Dance Dance;

    //ゲームの状態を表す変数
    enum Phase { 
        Leading = 0,
        Following = 1
        //Waitingなど演出フェーズがある場合、追加してよい
    }


    Phase phase = 0;

    // Start is called before the first frame update
    void Start()
    {
     //ダンスを生成
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Danceを生成する
            TogglePhase();
        }
    }

    //デバッグ用にキー入力でフェーズを入れ替えられるように
    void TogglePhase()
    {
        //プロトの仕様. 0と 1を交互に行う
        phase = (1 - phase);

    }

    //Danceを生成する関数
    private void MakeDance()
    {
        Debug.Log("PlayerStart DanceLeading");
    }

}
