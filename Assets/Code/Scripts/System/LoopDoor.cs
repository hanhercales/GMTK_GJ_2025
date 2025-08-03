using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LoopDoor : MonoBehaviour
{
    public bool isLooping = true;

    [SerializeField] private Transform targetDoor;
    [SerializeField] private Transform playerPosistion;
    [SerializeField] private EndDoor endDoor;
    [SerializeField] private InteractableObject thisInteractableObject;

    public void ClickToGoToDoor(string loopChar)
    {
        if(isLooping) GoToDoor(loopChar);
        else thisInteractableObject.gameObject.SetActive(false);
    }

    private void GoToDoor(string loopChar)
    {
        StartCoroutine(TeleportDelay(1f));
        if (!string.IsNullOrEmpty(loopChar))
        {
            endDoor.currentLoopQueue.Enqueue(loopChar[0]);
        }
    }

    private IEnumerator TeleportDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        playerPosistion.position = targetDoor.position;
    }
}