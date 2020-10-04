using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChecker : MonoBehaviour
{

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0.1f)
        {
            GameObject.Destroy(this.gameObject);
        }
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Notes")
        {
            ScoreManager.Instance.Score++;
            ScoreManager.Instance.CalledShowSprite = false;

        }

        Debug.Log("♬");
        //ノーツを消滅させる

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("♬");
    }
}
