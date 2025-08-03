using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinePicture : MonoBehaviour
{
    [SerializeField] private GameObject[] pictureImage = new GameObject[4];
    [SerializeField] private ItemFunction itemFunction;
    
    public void PictureCombine()
    {
        int activePicture = 0;
        for (int i = 0; i < pictureImage.Length; i++)
        {
            if (pictureImage[i].activeSelf)
            {
                activePicture++;
            }
        }
        
        if(activePicture == pictureImage.Length)
            itemFunction.TakeItem();
        else
            itemFunction.SetNoti("Need " + (pictureImage.Length - activePicture) + " more picture.");
    }
}
