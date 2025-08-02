using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private UnityEvent onInteraction;
    [SerializeField] private float interactionRange = 1f;
    [SerializeField] private ParticleSystem particleEffect;

    public float GetInteractionRange()
    {
        return interactionRange;
    }

    private void OnMouseEnter()
    {
        if (particleEffect == null) return;
        particleEffect.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (particleEffect == null) return;
        particleEffect.gameObject.SetActive(false);
    }

    public void OnInteract()
    {
        onInteraction.Invoke();
        if (particleEffect == null) return;
        particleEffect.gameObject.SetActive(false);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow; 
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
