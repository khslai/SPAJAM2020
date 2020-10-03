// Note
// ノーツクラス

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] float disappearTime = 3f;

    public float SpawnTime { get; set; } = 0f;

    private float destroyTimer = 0f;
    private bool mirrored = false;

    public GameObject RippleinFX;
    public GameObject RippleoutFX;

    void Start()
    {
        Instantiate(RippleinFX, this.transform.position, Quaternion.identity);
    }

    void Update()
    {
        destroyTimer += Time.deltaTime;

        if (destroyTimer >= disappearTime)
        {
            if (!mirrored)
            {
                // リードフェイスでActiveをfalseをしておく
                gameObject.SetActive(false);
            }
            else
            {
                // フォロワーフェイスで終了したらオブジェクト破壊
                Destroy(this.gameObject);
            }
        }
    }

    // ノーツのミラーにする
    public void ObjectMirror()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(-transform.position.x, -transform.position.y, 0f);
        Instantiate(RippleoutFX, this.transform.position, Quaternion.identity);
        destroyTimer = 0f;
        mirrored = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "HitChecker")
        {
            //得点の制御


            //ノーツを消滅させる
            GameObject.Destroy(this.gameObject);
        }

    }
}
