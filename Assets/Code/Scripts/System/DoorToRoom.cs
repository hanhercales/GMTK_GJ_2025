using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToRoom : MonoBehaviour
{
    [SerializeField] private Transform targetRoom;
    [SerializeField] private Transform playerPosistion;
    [SerializeField] private Transform cameraPosistion;
    [SerializeField] private Transform targetCameraPositon;

    private void GoToRoom()
    {
        playerPosistion.position = targetRoom.position;
        cameraPosistion.position = targetCameraPositon.position;
    }

    public void ClickToGoToRoom()
    {
        StartCoroutine(TeleportDelay(1f));
    }

    private IEnumerator TeleportDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        GoToRoom();
    }
}
