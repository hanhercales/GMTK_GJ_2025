using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EndDoor : MonoBehaviour
{
    public string endLoopString = "";
    public int endLoopStringLength = 0;
    public string currentLoopString = "";
    [SerializeField] private InteractableObject thisInteractableObject;
    [SerializeField] private TextMeshProUGUI endLoopText;

    private void Awake()
    {
        for(int i = 0; i < endLoopStringLength; i++)
            endLoopString += Random.Range(0, 2);
        endLoopText.text = endLoopString;
        
        thisInteractableObject.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (endLoopString == currentLoopString)
        {
            thisInteractableObject.gameObject.SetActive(true);
        }
        
        if(currentLoopString.Length > endLoopStringLength) currentLoopString = "";
    }
    
    public void ChangeScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}
