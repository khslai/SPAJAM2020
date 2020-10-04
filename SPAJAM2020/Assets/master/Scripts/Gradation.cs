using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gradation : MonoBehaviour
{
    private Animator animator = null;
    private bool phaseStart = false;
    private float scalePerFrame = 0f;
    private float scale = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        scalePerFrame = Time.deltaTime / GameManager.Instance.Dance.DanceTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (phaseStart)
        {
            scale -= scalePerFrame;
            if (scale > 0f)
            {
                transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(0f, transform.localScale.y, transform.localScale.z);
                phaseStart = false;
            }
        }
    }

    public void PlayPhaseStartAnim()
    {
        animator.SetTrigger("PhaseStart");
        scale = 1f;
        Invoke("SetPhaseStart", 1f);
    }


    private void SetPhaseStart()
    {
        phaseStart = true;
    }
}
