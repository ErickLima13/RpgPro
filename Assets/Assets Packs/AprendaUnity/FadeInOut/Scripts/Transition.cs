using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public static Transition _instance;
    private Animator anim;
    public bool isFadeComplete;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

   public void Fade()
    {
       anim.SetTrigger("Fade");
    }

    void FadeComplete()
    {
        isFadeComplete = true;
    }

    void StartFade()
    {
        isFadeComplete = false;
    }
}
