using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopDoor : MonoBehaviour
{
    public bool isLooping = true;
    public bool loopCode = false;

    [SerializeField] private string loopCodeString;
    [SerializeField] private Transform targetLocation;
    [SerializeField] private Transform loopLocation;
    [SerializeField] private GameObject player;

    public void GoInDoor()
    {
        if(!isLooping)
        {
            player.transform.position = targetLocation.position;
        }
        else
        {
            player.transform.position = loopLocation.position;
            
            string loopString = "";
            if (loopCode) loopString += '1';
            else loopString += '0';

            if (loopString == loopCodeString) isLooping = false;
        }
    }
}