using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EndDoor : MonoBehaviour
{
    public string endLoopString = "";
    public int endLoopStringLength = 0;
    public Queue<char> currentLoopQueue = new Queue<char>();
    
    [SerializeField] private string currentLoopString = "";
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
        if (new string(currentLoopQueue.ToArray()) == endLoopString)
        {
            thisInteractableObject.gameObject.SetActive(true);
        }
    }

    public void CheckLoopString(string loopChar)
    {
        if (currentLoopString.Length == endLoopStringLength)
        {
            currentLoopQueue.Dequeue();
        }
        
        currentLoopQueue.Enqueue(loopChar[0]);
        currentLoopString = new string(currentLoopQueue.ToArray());
    }
    
    public void ChangeScene(int sceneIndex)
    {
        PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(Delay(sceneIndex, 1f));
    }

    private IEnumerator Delay(int sceneIndex, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
