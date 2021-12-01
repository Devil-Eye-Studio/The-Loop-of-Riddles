using UnityEngine;


public class Interactive : MonoBehaviour
{

    [SerializeField] private float rayDistance;
    [SerializeField] private float motionSpeed;  

    [SerializeField] private Character character;
    [SerializeField] private CameraScript[] cameraScript;
    [SerializeField] private KeyManager keyManager;

    [SerializeField] private Transform itemPosition;


    [SerializeField] private CodeLockManager codeLockManager;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject interactText;

    private bool isTaken;

    private RaycastHit hit;
    private Ray ray;

    private Transform _selection;

    void Update()
    {
        if(_selection != null)
        {
            var selectionOutline = _selection.GetComponent<Outline>();
            selectionOutline.OutlineWidth = 0;
            interactText.SetActive(false);
            _selection = null;
        }

        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

        if(Physics.Raycast(ray, out hit, rayDistance))
        {            
            var selection = hit.transform;

            WatchOnCockroach();

            if (selection.gameObject.layer == 3)
            {
                interactText.SetActive(true);
                var selectionOutline = selection.GetComponent<Outline>();
                if (selectionOutline != null) 
                {
                    selectionOutline.OutlineWidth = 5;
                }
                _selection = selection;


                InteractionWithObjects();

                EnterCode();

                if (Input.GetButtonDown("Use"))
                {
                    DoorLock();

                    KeyPickUp();

                    TurnsLightOn();

                    OpenLocker();

                    MovableObject();
                }
                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    pauseMenu.enabled = true;
                }

                if (isTaken) hit.collider.transform.position = Vector3.Lerp(hit.collider.transform.position, itemPosition.transform.position, motionSpeed * Time.deltaTime);
            }
        }
            
    }

    private void InteractionWithObjects()
    {
        if (hit.collider.tag == "Interactive Object")
        {
            InteractiveObject interactiveObject = hit.collider.GetComponent<InteractiveObject>();
            ObjectInspection objectInspection = hit.collider.GetComponent<ObjectInspection>();

            if (Input.GetButtonDown("Use"))
            {
                interactiveObject.isPutBack = false;
                isTaken = true;
                DisableControls();
                objectInspection.enabled = true;

                if (hit.collider.GetComponent<Note>() && !hit.collider.GetComponent<Note>().isPickedUp)
                {
                    hit.collider.GetComponent<Note>().isPickedUp = true;
                    hit.collider.GetComponent<Note>().MakeNote();
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (hit.collider.GetComponent<Note>()) 
                {
                    hit.collider.GetComponent<Note>().CloseNote();
                    hit.collider.GetComponent<Note>().isPickedUp = false;
                }
                    
                objectInspection.enabled = false;
                isTaken = false;
                EnableControls();
                interactiveObject.isPutBack = true;
            }
        }
    }

    private void DoorLock() // Open/Close Door
    {
        if (hit.collider.tag == "Door")
        {
            DoorScript door = hit.collider.GetComponent<DoorScript>();
            if(!door.isLocked || (door.isLocked && keyManager.KeyPickedUp == true))
            {
                if (!door.isOpened)
                {
                    door.OpenDoor();
                    if (door.isScriptableDoor) keyManager.KeyPickedUp = false;
                }
                else
                {
                    door.CloseDoor();
                }              
            }
        }
    } 

    private void MovableObject()
    {
        if(hit.collider.tag == "Movable Object")
        {
            hit.collider.GetComponent<MoveObject>().isMove = true;
        }
    }

    private void KeyPickUp()
    {
        if(hit.collider.tag == "Key")
        {
            var key = hit.collider;

            keyManager.KeyPickedUp = true;
            interactText.SetActive(false);

            key.GetComponent<AudioSource>().Play();
            key.GetComponent<MeshRenderer>().enabled = false;
            key.GetComponent<Collider>().enabled = false;
        }
    }

    private void OpenLocker()
    {
        if (hit.collider.tag == "Locker")
        {
            Locker lockerScript = hit.collider.GetComponent<Locker>();
            
            if(!lockerScript.isOpen)
            {
                lockerScript.OpenLocker();
            }
            else
            {
                lockerScript.CloseLocker();
            }
        }
    }

    private void TurnsLightOn()
    {     
        if (hit.collider.tag == "Switch")
        {
            LightSwitch lightSwitch = hit.collider.GetComponent<LightSwitch>();
            if (!lightSwitch.isOn)
            {
                lightSwitch.TurnOn();
            }
            else
            {
                lightSwitch.TurnOff();
            }
        }
    }

    private void EnterCode()
    {
        if(hit.collider.tag == "Code Lock")
        {
            CodeLockNumbers codeLockNumbers = hit.collider.GetComponent<CodeLockNumbers>();

            codeLockManager.rightCode = codeLockNumbers.codeOfLock;

            if (codeLockManager.enteredCode == codeLockManager.rightCode && !codeLockNumbers.isCutscene) 
            {
                EnableControls();
                hit.collider.GetComponent<Animator>().SetTrigger("Open");
                hit.transform.gameObject.layer = 0;
            }
            
            if(!codeLockManager.isOpened)
            {
                if (Input.GetButtonDown("Use"))
                {
                    codeLockNumbers.lockPanel.SetActive(true);
                    DisableControls();
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    codeLockNumbers.lockPanel.SetActive(false);
                    EnableControls();
                }
            }              
        }
        else
        {
            codeLockManager.isOpened = false;
        }
    }

    private void WatchOnCockroach()
    {
        if(hit.collider.tag =="Cockroach")
        {
            hit.collider.GetComponent<Collider>().enabled = false;
            hit.collider.GetComponent<Animator>().SetTrigger("Run");
            hit.collider.GetComponent<AudioSource>().Play();
        }
    }

    private void DisableControls()
    {
        Cursor.lockState = CursorLockMode.Confined;
        character.enabled = false;
        cameraScript[0].enabled = false;
        cameraScript[1].enabled = false;
        pauseMenu.enabled = false;
    }

    private void EnableControls()
    {
        Cursor.lockState = CursorLockMode.Locked;
        character.enabled = true;
        cameraScript[0].enabled = true;
        cameraScript[1].enabled = true;
        pauseMenu.enabled = true;
    }
}
