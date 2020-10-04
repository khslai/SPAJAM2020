using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// InputManager : 入力マネージャー

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    [SerializeField] GameManager gameManager;

    [SerializeField] Note note = null;
    [SerializeField] GameObject HitCheckerPrefab = null;

    public Vector3 TouchedPos; 
    void Start()
    {
        if (note == null)
        {
            Debug.LogError("Please set note to the " + name + "'s inspector.");
        }
        if (HitCheckerPrefab == null)
        {
            Debug.LogError("Please set HitCheckerPrefab to the " + name + "'s inspector.");
        }
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

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0f;
        TouchedPos = worldPos;
        //Debug.Log("worldPos" + worldPos.x + " " + worldPos.y + " " + worldPos.z);

        if (gameManager.phase == GameManager.GamePhase.Following)
        {
            //Hitチェッカーを作成
            GameObject.Instantiate(HitCheckerPrefab, worldPos, Quaternion.identity);

            Debug.Log("Touched In Following");
        }
        else if(gameManager.phase == GameManager.GamePhase.Leading)
        {
            Note temp = Instantiate(note);
            temp.transform.position = worldPos;
            temp.SpawnTime = spawnTime;

            // ノーツを記録する処理
            GameManager.Instance.RespawnNotesList.Add(temp);
            Debug.Log("Touched In Leading");
        }
        else if (gameManager.phase == GameManager.GamePhase.Title)
        {
            GameManager.Instance.ChangePhase(GameManager.GamePhase.Leading);
        }
        else if (gameManager.phase == GameManager.GamePhase.Final)
        {
            GameManager.Instance.Final.FinalShakeAnimator.SetTrigger("Trigger2");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

    }
}
