using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI _instance;
    public Text headsetText;
    public Text hatText;

    private Animator anim;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        //DontDestroyOnLoad()只能在根物体使用
         DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        headsetText.text = ScoreController._instance.Score.x.ToString();
        hatText.text = ScoreController._instance.score.y.ToString();
    }

    public void ShowUI()
    {
        anim.SetTrigger("show");
    }
}
