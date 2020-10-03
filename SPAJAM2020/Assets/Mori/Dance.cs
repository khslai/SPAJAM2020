using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dance : MonoBehaviour
{
    //ArrayList<Notes>() noteslist;
    public class notesData{
        public Vector2 pos;
        public float time;
    }


    public List<notesData> notesList = new List<notesData>();


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //リード側がノーツを記録する処理
    public void AddNotes(Vector2 pos, float time)
    {
        notesData data = new notesData();
        data.pos = pos;data.time = time;
        notesList.Add(data);
    }

}
