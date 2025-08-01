using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LoopDoor : MonoBehaviour
{
    public bool isLooping = true;
    public string endLoopString = "";

    [SerializeField] private string currentLoopString = "";
    [SerializeField] private Transform targetDoor;
    [SerializeField] private GameObject doorC;
    [SerializeField] private Transform playerPosistion;
    [SerializeField] private int endLoopStringLength = 7;

    private void Awake()
    {
        for (int i = 0; i < endLoopStringLength; ++i)
        {
            endLoopString +=Random.Range(0, 2);
        }
    }

    public void ClickToGoToDoor(string loopChar)
    {
        if(isLooping) GoToDoor(loopChar);
    }

    private void GoToDoor(string loopChar)
    {
        playerPosistion.position = targetDoor.position;
        
        currentLoopString += loopChar;
        
        if (currentLoopString.Equals(endLoopString))
        {
            isLooping = false;
            doorC.SetActive(true);
        }

        if (currentLoopString.Length > endLoopStringLength) currentLoopString = null;
    }
}