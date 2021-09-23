using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController _instance;
    public Vector2 score;

    public Vector2 Score
    {
        get
        {
            return score;
        }
    }

    private void Awake()
    {
        if (_instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance=this;
        }

        DontDestroyOnLoad(gameObject);  //游戏物体不会被销毁
    }

    public void addScore(int index)
    {
        int addIndex = (index + 1) % 2;
        score[addIndex]++;
    }
}
