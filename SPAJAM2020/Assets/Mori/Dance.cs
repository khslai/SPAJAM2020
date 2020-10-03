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
    }

    public void DoUninit()
    {
    }
}
