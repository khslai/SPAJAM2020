using UnityEngine;
using System.Collections;

public class Final : MonoBehaviour
{
    public Animator FinalShakeAnimator;

    public float TitleAnimationTime = 5.0f;
    public void DoUpdate()
    {
        //一定時間経過後にタッチしたら次に進むように

        //仮実装: シーンを再読み込みするように

        if (GameManager.Instance.timer > TitleAnimationTime)
        {
            InputManager.Instance.ButtonDown(0);
            //FinalShakeAnimator.SetTrigger("Trigger1");
        }

    }
    public void DoInitialize()
    {
        FinalShakeAnimator.SetTrigger("Trigger");
    }

}
