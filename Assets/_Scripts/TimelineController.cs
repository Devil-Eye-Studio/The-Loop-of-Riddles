using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{

    [SerializeField] private CodeLockManager codeLockManager;
    [SerializeField] private CodeLockNumbers codeLockNumbers;

    private PlayableDirector timelineAnimation;

    private void Start()
    {
        timelineAnimation = GetComponent<PlayableDirector>();
    }

    private void Update()
    {
        if (codeLockNumbers.codeOfLock == codeLockManager.enteredCode && codeLockNumbers.isCutscene) timelineAnimation.Play();
    }
}
