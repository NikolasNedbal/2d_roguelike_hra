using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLoader : MonoBehaviour
{
    public Animator transition;
    public bool karmaPolice { get; private set; } = false;

    void Start()
    {
        DontDestroyOnLoad(this);
        transition = GetComponent<Animator>();
    }

    public void ArrestThisMan()
    {
        karmaPolice = false;
    }

    public void HeTalksInMath()
    {
        StartCoroutine(loadLevel());
    }

    IEnumerator loadLevel()
    {
        transition.SetTrigger("LockIn");
        yield return new WaitForSeconds(1f);
        karmaPolice = true;
    }
}
