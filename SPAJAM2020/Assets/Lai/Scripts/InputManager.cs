using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// InputManager : 入力マネージャー

public class InputManager : MonoBehaviour
{
    void Update()
    {
        //var touch = Input.GetTouch(0);
        //switch (touch.phase)
        //{
        //    // 画面に指が触れた時に行いたい処理をここに書く
        //    case TouchPhase.Began:

        //        ButtonDown();
        //        break;

        //    // 画面上で指が動いたときに行いたい処理をここに書く
        //    case TouchPhase.Moved:
        //        break;
        //    // 指が画面に触れているが動いてはいない時に行いたい処理をここに書く
        //    case TouchPhase.Stationary:
        //        break;
        //    // 画面から指が離れた時に行いたい処理をここに書く
        //    case TouchPhase.Ended:
        //        break;
        //    // システムがタッチの追跡をキャンセルした時に行いたい処理をここに書く
        //    case TouchPhase.Canceled:
        //        break;
        //}

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            ButtonDown();
        }
#endif
    }

    private void ButtonDown()
    {
        Debug.Log("Touch");
    }
}
