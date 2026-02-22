using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public GameObject interactText;
    private Vector2 inputData;
    private CharacterController controller;
    public Animator animator;
    [SerializeField] public TextManager TextManager;
    
    private PlayerInput inputMap;

    [SerializeField] private Transform cameraTransform;
    
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed = 10f;
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

    private void Start()
    {
        LockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (!freezePlayer) 
            MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 rawDir = camForward * inputData.y + camRight * inputData.x;

        if (rawDir.magnitude > 1f)
            rawDir.Normalize();

        if (controller.isGrounded && yVelocity < 0)
            yVelocity = -2f;

        yVelocity += Physics.gravity.y * Time.deltaTime;

        Vector3 move = rawDir * speed;
        move.y = yVelocity;

        if (rawDir.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rawDir);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
        
        controller.Move(move * Time.deltaTime);
    }

    private void Interact(GameObject obj)
    {
        Debug.Log("Enter bonfire");
        UnlockCursor();
        BonfireUIManager.Instance.ToggleBonfire("Open");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonfire"))
        {
            interactText.SetActive(true);
            Debug.Log("Bonfire available");
            interactable = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bonfire"))
        {
            interactText.SetActive(false);
            Debug.Log("Bonfire unavailable");
            interactable = null;
        }
    }
    
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
