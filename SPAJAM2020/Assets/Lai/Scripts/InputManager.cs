using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// InputManager : 入力マネージャー

public class InputManager : MonoBehaviour
{
    [SerializeField] Note note = null;
    [SerializeField] DanceFollowing danceFollowing = null;

    void Update()
    {

    }

    public void ButtonDown(float spawnTime)
    {
        bool flag = false;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            flag = true;
        }
#else
        var touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            flag = true;
        }
#endif

        if (!flag)
        {
            return;
        }

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0f;
        //Debug.Log("worldPos" + worldPos.x + " " + worldPos.y + " " + worldPos.z);

        Note temp = Instantiate(note);
        temp.transform.position = worldPos;
        temp.SpawnTime = spawnTime;

        // TODO: Dance.AddNotes()を呼び出してNoteを追加する
        danceFollowing.RespawnNotesList.Add(temp);
    }
}
