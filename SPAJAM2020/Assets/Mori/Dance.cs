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

    [SerializeField] private GameManager gameManager;

    //ArrayList<Notes>() noteslist;


    public List<notesData> notesList = new List<notesData>();

    /// <summary>
    /// ステートが始まってからの時間
    /// </summary>
    public float timer = 0;

    public void DoInitialize()
    {
        timer = 0;
    }

    public void DoUpdate()
    {
        timer += Time.deltaTime;
    }

    //リード側がノーツを記録する処理
    public void AddNotes(Vector2 pos, float time)
    {
        if (gameManager.phase == GameManager.Phase.Leading)
        {
            notesData data = new notesData();
            data.pos = pos; data.time = time;
            notesList.Add(data);
        }
    }

}
