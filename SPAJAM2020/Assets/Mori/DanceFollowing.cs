using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DanceFollowing : MonoBehaviour
{
    public List<Note> RespawnNotesList { get; private set; } = new List<Note>();

    /// <summary>
    /// ステートが始まってからの時間
    /// </summary>
    //private float timer = 0f;

    public void DoInitialize()
    {
        //timer = 0;
    }

    public void DoUpdate()
    {
        //timer += Time.deltaTime;

        if (RespawnNotesList.Count != 0 && GameManager.Instance.timer >= RespawnNotesList[0].SpawnTime)
        {
            RespawnNotesList[0].ObjectMirror();
            RespawnNotesList.RemoveAt(0);
        }
    }

    public void DoUninit()
    {
        RespawnNotesList.Clear();
    }
}
