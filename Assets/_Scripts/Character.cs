using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float crouchSpeed;
    private float standartSpeed;

    [SerializeField] private float gravity;

    [SerializeField] private float crouchHeight; // Character height when sitting
    private float standartHeight; // The normal height of character

    [SerializeField] private GameObject flashlight;
    private bool isFlashlightOn;
    [SerializeField] private AudioSource flashlightAudioSource;
    [SerializeField] private AudioClip flashlightAudio;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] footSteps;
    [SerializeField] private float timeToStep;
    private float usageTimeToStep;
    private bool isStep;

    private Vector3 moveDirection = Vector3.zero;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        LoadPlayer();
        controller.enabled = true;
        standartHeight = controller.height;
        standartSpeed = speed;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Flashlight"))
        {
            if (!isFlashlightOn)
            {
                flashlight.SetActive(true);
                isFlashlightOn = true;
            }              
            else
            {
                flashlight.SetActive(false);
                isFlashlightOn = false;
            }

            flashlightAudioSource.PlayOneShot(flashlightAudio);
        }
        
    }

    void FixedUpdate()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);

        moveDirection *= standartSpeed;

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetButton("Crouch"))
        {
            standartSpeed = crouchSpeed;
            controller.height = crouchHeight;
        }
        else
        {
            controller.height = standartHeight;
            standartSpeed = speed;
        }

        if(moveDirection.x != 0)
        {
            isStep = true;
            if(usageTimeToStep <= 0)
            {
                int footStepIndex = Random.Range(0, footSteps.Length);
                audioSource.PlayOneShot(footSteps[footStepIndex]);

                isStep = false;
                usageTimeToStep = timeToStep;
            }
            
        }

        if(isStep)
        {
            usageTimeToStep -= Time.deltaTime;
        }
    }

    private void LoadPlayer()
    {
        Vector3 playerPosition;
        if (PlayerPrefs.HasKey("PositionX"))
        {
            playerPosition.x = PlayerPrefs.GetFloat("PositionX");
            playerPosition.y = PlayerPrefs.GetFloat("PositionY");
            playerPosition.z = PlayerPrefs.GetFloat("PositionZ");

            transform.position = playerPosition;
        }        
    }
}
