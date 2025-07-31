using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private const string IDLE = "Idle";
    private const string RUN = "Run";
    private const string INTERACT = "Attack";

    private CustomActions input;
    private NavMeshAgent agent;
    Animator animator;
    
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    private float lookRotationSpeed = 8f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        input = new CustomActions();
        AssignInputs();
    }

    private void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
        input.Main.Interact.performed += ctx => Interact();
    }
    
    private void ClickToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(INTERACT)) return;
            
            agent.SetDestination(hit.point);
            if (clickEffect != null)
            {
                Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);
            }
        }
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        if(agent.velocity.magnitude > 0.1f)
        {
            FaceTarget();
        }
        SetAnimations();
    }
    
    private void FaceTarget()
    {
        Vector3 direction = (agent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
    }

    private void SetAnimations()
    {
        bool isInteracting = animator.GetCurrentAnimatorStateInfo(0).IsName(INTERACT);
        
        if(isInteracting) return;
        
        if (agent.velocity == Vector3.zero)
        {
            animator.Play(IDLE);
        }
        else
        {
            animator.Play(RUN);
        }
    }

    private void Interact()
    {
        agent.ResetPath();
        animator.SetTrigger(INTERACT);
    }
}
