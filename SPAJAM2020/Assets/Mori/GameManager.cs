using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject DancePrefab;

    // Start is called before the first frame update
    void Start()
    {
     //ダンスを生成
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //デバッグ用にキー入力でフェーズを入れ替えられるように
    void TogglePhase()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Danceを生成する
            MakeDance();


        }

    }

    //Danceを生成する関数
    private void MakeDance()
    {
        Debug.Log("PlayerStart DanceLeading");
        //空のダンスオブジェクトを作成
        GameObject.Instantiate(DancePrefab);
    }

}
