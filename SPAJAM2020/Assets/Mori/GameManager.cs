using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] private float phaseTime = 5f;
    [SerializeField] private Dance dance = null;
    [SerializeField] private DanceFollowing danceFollowing = null;
    [SerializeField] private Text phaseText = null;

    public Dance Dance { get { return dance; } }
    public DanceFollowing DanceFollowing { get { return danceFollowing; } }

    //ゲームの状態を表す変数
    public enum GamePhase
    {
        Leading = 0,
        Following = 1,
        Waiting = 2,
        Title = 3,
        Final = 4
        //Waitingなど演出フェーズがある場合、追加してよい
    }
    public GamePhase phase = GamePhase.Leading;

    public float timer { get; private set; } = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (dance == null)
        {
            Debug.LogError("Please set dance to the " + name + "'s inspector.");
        }
        if (danceFollowing == null)
        {
            Debug.LogError("Please set danceFollowing to the " + name + "'s inspector.");
        }
        if (phaseText == null)
        {
            Debug.LogError("Please set phaseText to the " + name + "'s inspector.");
        }

        //ダンスを生成
        Debug.Log("PlayerStart DanceLeading");
        phaseText.text = "Leading Phase";
    }

    // Update is called once per frame
    void Update()
    {
        //
        switch (phase)
        {
            case GamePhase.Leading:

                timer += Time.deltaTime;
                Dance.DoUpdate();
                break;

            case GamePhase.Following:

                timer += Time.deltaTime;
                DanceFollowing.DoUpdate();
                break;

            default:
                break;
        }

        if (timer >= phaseTime || Input.GetKeyDown(KeyCode.Space))
        {
            // Phaseを切り替える
            TogglePhase();
        }
    }

    //デバッグ用にキー入力でフェーズを入れ替えられるように
    void TogglePhase()
    {
        timer = 0f;

        //プロトの仕様. 0と 1を交互に行う
        if (phase == GamePhase.Leading)
        {
            Debug.Log("PlayerStart DanceFollowing");
            phaseText.text = "Following Phase";
            phase = GamePhase.Following;
            DanceFollowing.DoInitialize();
        }
        else if (phase == GamePhase.Following)
        {
            Debug.Log("PlayerStart DanceLeading");
            phaseText.text = "Leading Phase";
            phase = GamePhase.Leading;
            DanceFollowing.DoUninit();
            Dance.DoInitialize();
        }
    }

    //TogglePhaseから乗り換える。
    void ChangePhase(GamePhase nextphase)
    {
        Debug.Log("PlayerStart" + nextphase.ToString());
        phase = nextphase;
        phaseText.text = nextphase.ToString();
        switch (phase) {
            case GamePhase.Leading: Dance.DoInitialize(); break;
            case GamePhase.Following: DanceFollowing.DoInitialize(); DanceFollowing.DoUninit();
                break;
        }

    }

    //Danceを生成する関数
    private void MakeDance()
    {
        Debug.Log("PlayerStart DanceLeading");
    }
}
