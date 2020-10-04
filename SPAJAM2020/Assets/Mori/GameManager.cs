using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] private Dance dance = null;
    [SerializeField] private ScoreManager scoreManager = null;
    [SerializeField] private DanceFollowing danceFollowing = null;
    [SerializeField] private Wait wait = null;
    [SerializeField] private Text phaseText = null;
    [SerializeField] private Text timerText = null;
    [SerializeField] float respawnTimeOffset = 1.2f;


    public Dance Dance { get { return dance; } }
    public DanceFollowing DanceFollowing { get { return danceFollowing; } }

    public ScoreManager ScoreManager { get { return scoreManager; } }
    public Wait Wait { get { return wait; } }
    public List<Note> RespawnNotesList { get; set; } = new List<Note>();

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

    public float timer = 0f;

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

            case GamePhase.Waiting:

                timer += Time.deltaTime;
                Wait.DoUpdate();
                break;

            default:
                break;
        }
        timerText.text = timer.ToString("00.00");
    }

    //デバッグ用にキー入力でフェーズを入れ替えられるように
    //void TogglePhase()
    //{
    //    timer = 0f;

    //    //プロトの仕様. 0と 1を交互に行う
    //    if (phase == GamePhase.Leading)
    //    {
    //        Debug.Log("PlayerStart DanceFollowing");
    //        phaseText.text = "Following Phase";
    //        phase = GamePhase.Following;
    //        DanceFollowing.DoInitialize();
    //    }
    //    else if (phase == GamePhase.Following)
    //    {
    //        Debug.Log("PlayerStart DanceLeading");
    //        phaseText.text = "Leading Phase";
    //        phase = GamePhase.Leading;
    //        DanceFollowing.DoUninit();
    //        Dance.DoInitialize();
    //    }
    //}

    //TogglePhaseから乗り換える。
    public void ChangePhase(GamePhase nextphase)
    {
        Debug.Log("PlayerStart" + nextphase.ToString());
        phase = nextphase;
        phaseText.text = nextphase.ToString();
        switch (phase)
        {
            case GamePhase.Leading:

                Dance.DoInitialize();
                RespawnNotesList.Clear();
                break;

            case GamePhase.Following:

                DanceFollowing.DoInitialize();
                break;

            default:
                break;
        }

        if (phase != GamePhase.Following)
        {
            timer = 0f;
        }
    }

    //各ノードを生成するタイミングの制御
    public void RespawnNote()
    {
        if (RespawnNotesList.Count != 0)
        {
            if (RespawnNotesList[0].SpawnTime <= respawnTimeOffset)
            {
                if (timer >= RespawnNotesList[0].SpawnTime)
                {
                    RespawnNotesList[0].ObjectMirror(respawnTimeOffset);
                    RespawnNotesList.RemoveAt(0);
                }
            }
            else
            {
                if (timer >= RespawnNotesList[0].SpawnTime - respawnTimeOffset)
                {
                    RespawnNotesList[0].ObjectMirror(respawnTimeOffset);
                    RespawnNotesList.RemoveAt(0);
                }
            }
        }
    }
}
