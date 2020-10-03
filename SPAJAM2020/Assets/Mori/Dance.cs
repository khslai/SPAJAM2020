using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dance : MonoBehaviour
{
    //ArrayList<Notes>() noteslist;
    List<Notes> notesList = new List<Notes>();


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //リード側がノーツを記録する処理
    public void AddNotes(Notes notes)
    {
        notesList.Add(notes);
    }

}
