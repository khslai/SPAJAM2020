using UnityEngine;
using System.Collections;

public class Wait : MonoBehaviour { 

    public GameManager gameManager;
    public float WaitTime = 0.5f;
    [HideInInspector]public GameManager.GamePhase nextnextphase;
    // Use this for initialization

    public void DoUpdate()
    {
        //時間によるシーン遷移
        if (gameManager.timer > WaitTime)
        {
            gameManager.ChangePhase(nextnextphase);
        }

    }
}
