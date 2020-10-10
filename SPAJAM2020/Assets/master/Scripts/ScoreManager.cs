using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DegreeData {
    public int Node_N = 3;
    public int Score = 0;
}


public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    [SerializeField] float ShowSpriteTime = 3f;
    [SerializeField] List<SpriteRenderer> backgourndSprites = new List<SpriteRenderer>();
    [SerializeField] List<int> backgourndScores = new List<int>();

    [SerializeField] public List<DegreeData> degrees = new List<DegreeData>();

    public int NowMaxNode_N = 1; 

    public int Score  = 0;

    public int ClearScore = 76;
    public bool CalledShowSprite { private get; set; } = false;

    private List<bool> showSpriteFlags = new List<bool>();
    private int spriteIndex = 0;
    private SpriteRenderer currentSprite = null;
    private float alphaPerFrame = 0f;

    public DanceFollowing Following_script;

    void Start()
    {
        foreach (var sprite in backgourndSprites)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0f);
            showSpriteFlags.Add(false);
        }
        alphaPerFrame = 1f * Time.deltaTime / ShowSpriteTime;
    }

    void Update()
    {
        foreach (var score in backgourndScores)
        {
            if (Score == score)
            {
                ShowSprite();
                backgourndScores.RemoveAt(0);
                break;
            }
        }

        for (int i = 0; i < showSpriteFlags.Count; i++)
        {
            if (showSpriteFlags[i])
            {
                float alpha = backgourndSprites[i].color.a + alphaPerFrame;
                if (alpha <= 1f)
                {
                    backgourndSprites[i].color = new Color(currentSprite.color.r, currentSprite.color.g, currentSprite.color.b, alpha);
                }
                else
                {
                    backgourndSprites[i].color = new Color(currentSprite.color.r, currentSprite.color.g, currentSprite.color.b, 1f);
                    showSpriteFlags[i] = false;
                }
            }
        }
    }

    private void ShowSprite()
    {
        if (CalledShowSprite)
        {
            return;
        }

        CalledShowSprite = true;
        currentSprite = backgourndSprites[spriteIndex];
        showSpriteFlags[spriteIndex] = true;
        spriteIndex++;
    }

    public void SetMaxNode_N()
    {
        foreach(DegreeData degree in degrees)
        {
            if (Score >= degree.Score)
                NowMaxNode_N = degree.Node_N;
        }
    }

    public void SetBackGroundObject()
    {

    }

    public void HitNote()
    {
        Following_script.HitNote();
    }

}
