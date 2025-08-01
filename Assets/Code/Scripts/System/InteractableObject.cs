using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private UnityEvent onInteraction;
    [SerializeField] private float interactionRange = 1f;

    public float GetInteractionRange()
    {
        return interactionRange;
    }

    public void OnInteract()
    {
        onInteraction.Invoke();
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow; 
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
