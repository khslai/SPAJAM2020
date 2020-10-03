// SingletonMonoBehaviour
// シーン中に一つしか存在しないシングルトンクラスの実装を行う

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    //シングルトンのインスタンスを格納
    static T instance;

    //インスタンスを外部から参照するためのgetter
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //シングルトンのインスタンスを取得していない場合は、シーン内から検索して取得
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    //取得できなかった場合はエラー
                    throw new NullReferenceException("Singleton Instantiate: <" + typeof(T) + "> is not found");
                }
            }
            return instance;
        }
    }

    protected void Awake()
    {
        CheckInstance();
    }

    //インスタンスの存在や重複をチェックする　重複していた場合は消す
    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = (T)this;
            return true;
        }
        else if (Instance == this)
        {
            return true;
        }
        else
        {
            Debug.LogWarning("Singleton <" + typeof(T) + "> overlapped (delete)");
            Destroy(this);
            return false;
        }
    }
}
