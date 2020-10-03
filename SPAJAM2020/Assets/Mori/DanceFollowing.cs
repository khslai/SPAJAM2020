using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DanceFollowing : MonoBehaviour
{
    public List<Note> RespawnNotesList { get; private set; } = new List<Note>();
    //public List<notesData> notesListFollow = new List<notesData>();

    //[SerializeField] private Dance dance;

    // Use this for initialization

    /// <summary>
    /// ステートが始まってからの時間
    /// </summary>
    public float timer = 0;
    public void DoInitialize()
    {
        //Dance側のnoteListをコピーする
        //notesListFollow = dance.notesList;
        timer = 0;
    }


    public void DoUpdate()
    {
        timer += Time.deltaTime;
    }

}
