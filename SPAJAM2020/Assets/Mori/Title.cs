using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour
{
    public Animator titleanimator;

    public float TitleAnimationTime = 1.0f;

    public void DoUpdate()
    {
        //一定時間経過後にタッチしたら次に進むように
        if (GameManager.Instance.timer > TitleAnimationTime)
        {
            InputManager.Instance.ButtonDown(0);
            titleanimator.SetTrigger("Trigger");
        }
    }
}
