using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// InputManager : 入力マネージャー

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    [SerializeField] Note note = null;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject HitCheckerPrefab;

    public Vector3 TouchedPos; 
    void Start()
    {
        if (note == null)
        {
            Debug.LogError("Please set note to the " + name + "'s inspector.");
        }
    }

    void Update()
    {
    }

    public void ButtonDown(float spawnTime)
    {
        bool flag = false;

//#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            flag = true;
        }
//#else
//        var touch = Input.GetTouch(0);
//        if (touch.phase == TouchPhase.Began)
//        {
//            flag = true;
//        }
//#endif
        if (!flag)
        {
            return;
        }


        if (gameManager.phase == GameManager.GamePhase.Following)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0f;
            TouchedPos = worldPos;
            //全ての
            //Debug.Log("worldPos" + worldPos.x + " " + worldPos.y + " " + worldPos.z);
            //Debug.LogError("worldPos" + worldPos.x + " " + worldPos.y + " " + worldPos.z);
            //Hitチェッカーを作成
            GameObject.Instantiate(HitCheckerPrefab, worldPos, Quaternion.identity);

            Debug.Log("Touched In Following");
        }
        else if(gameManager.phase == GameManager.GamePhase.Leading)
        {

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0f;
            //Debug.Log("worldPos" + worldPos.x + " " + worldPos.y + " " + worldPos.z);

            Note temp = Instantiate(note);
            temp.transform.position = worldPos;
            temp.SpawnTime = spawnTime;

            // ノーツを記録する処理
            GameManager.Instance.DanceFollowing.RespawnNotesList.Add(temp);
            Debug.Log("Touched In Leading");

        }



    }

    //
    public void ButtonDownFollowing()
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


    }
}
