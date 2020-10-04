using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    [SerializeField] float ShowSpriteTime = 3f;
    [SerializeField] List<SpriteRenderer> backgourndSprites = new List<SpriteRenderer>();
    [SerializeField] List<int> backgourndScores = new List<int>();


    public int Score { get; set; } = 0;
    public bool CalledShowSprite { private get; set; } = false;

    private List<bool> showSpriteFlags = new List<bool>();
    private int spriteIndex = 0;
    private SpriteRenderer currentSprite = null;
    private float alphaPerFrame = 0f;

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
}
