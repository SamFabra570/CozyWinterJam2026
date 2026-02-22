using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    
    private Vector2 inputData;
    private CharacterController controller;
    public Animator animator;
    [SerializeField] public TextManager TextManager;
    
    private PlayerInput inputMap;
    
    [SerializeField] private float speed;
    private float yVelocity;

    private GameObject interactable;

    public bool freezePlayer;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        
        Instance = this;
        TextManager = new TextManager();
        
        controller = gameObject.AddComponent<CharacterController>();
        //animator = GetComponent<Animator>();
        //rend = GetComponent<Renderer>();
        
        inputMap = new PlayerInput();
        
        inputMap.Player.Movement.performed += Movement_performed =>
        {
            inputData = Movement_performed.ReadValue<Vector2>();
            animator.SetBool("isWalking", true);
        };
        
        inputMap.Player.Movement.canceled += Movement_canceled =>
        {
            inputData = Movement_canceled.ReadValue<Vector2>();
            animator.SetBool("isWalking", false);
        };

        inputMap.Player.Interact.performed += context =>
        {
            if (interactable == null)
                return;
            
            Interact(interactable);
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (!freezePlayer) 
            MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 rawDir = new Vector3(inputData.x, 0, inputData.y);

        if (rawDir.magnitude > 1f)
            rawDir.Normalize();

        if (controller.isGrounded && yVelocity < 0)
            yVelocity = -2f;

        yVelocity += Physics.gravity.y * Time.deltaTime;

        Vector3 move = rawDir * speed;
        move.y = yVelocity;

        controller.Move(move * Time.deltaTime);
    }

    private void Interact(GameObject obj)
    {
        Debug.Log("Enter bonfire");
        BonfireUIManager.Instance.ToggleBonfire("Open");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonfire"))
        {
            Debug.Log("Bonfire available");
            interactable = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bonfire"))
        {
            Debug.Log("Bonfire unavailable");
            interactable = null;
        }
    }


    private void OnEnable()
    {
        inputMap.Enable();
    }

    private void OnDisable()
    {
        inputMap.Disable(); 
    }
}
