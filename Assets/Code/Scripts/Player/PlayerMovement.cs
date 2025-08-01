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
        input.Main.Move.performed += ctx => RightClickToMove();
        input.Main.Interact.performed += ctx => LeftClickToInteract();
    }
    
    private void RightClickToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            if (hit.collider.GetComponent<InteractableObject>() != null)
                return;
            
            agent.SetDestination(hit.point);
        }
    }

    private void LeftClickToInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                float distance = Vector3.Distance(transform.position, interactable.transform.position);
                
                if (distance <= interactable.GetInteractionRange())
                {
                    FaceTarget(interactable.transform.position);
                    interactable.OnInteract();
                    Interact();
                }
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
        SetAnimations();
        
        if(agent.velocity.sqrMagnitude > 0.1f)
        {
            FaceTarget(agent.destination);;
        }
    }
    
    private void FaceTarget(Vector3 destination)
    {
        Vector3 direction = (destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
    }

    private void SetAnimations()
    {
        bool isInteracting = animator.GetCurrentAnimatorStateInfo(0).IsName(INTERACT);
        
        if(isInteracting) return;
        
        if (agent.hasPath && agent.remainingDistance > agent.stoppingDistance + 0.1f)
        {
            animator.Play(RUN);
        }
        else
        {
            animator.Play(IDLE);
        }
    }

    private void Interact()
    {
        agent.ResetPath();
        animator.SetTrigger(INTERACT);
    }
}
