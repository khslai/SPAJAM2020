using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] float disappearTime = 5f;

    public float SpawnTime { get; set; } = 0f;

    private float destroyTimer = 0f;
    private bool mirrored = false;

    void Update()
    {
        destroyTimer += Time.deltaTime;

        if (destroyTimer >= disappearTime)
        {
            if (!mirrored)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void ObjectMirror()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(-transform.position.x, -transform.position.y, 0f);
        mirrored = true;
    }
}
