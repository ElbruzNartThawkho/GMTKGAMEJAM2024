using UnityEngine;

public class RotatingDoor : MonoBehaviour
{
    public Transform door;              // Door object
    public float openAngle = -90f;      // Angle to open the door
    public float rotateSpeed = 2f;      // Speed of door rotation

    private Quaternion doorClosedRot;   // Closed rotation of the door
    private Quaternion doorOpenRot;     // Open rotation of the door

    private bool isOpening = false;     // Whether the door is opening
    private bool isClosing = false;     // Whether the door is closing
    private bool isClosed;

    private bool hasOpened = false;     // Kapının açıldığını izlemek için
    private bool hasClosed = true;      // Kapının kapandığını izlemek için

    private AudioSource audioSource;    // AudioSource for playing sound

    void Start()
    {
        // Save the initial rotation of the door
        doorClosedRot = door.rotation;

        // Calculate the open rotation of the door
        doorOpenRot = Quaternion.Euler(doorClosedRot.eulerAngles + new Vector3(0, openAngle, 0));

        // Get the AudioSource component attached to the door
        audioSource = door.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isOpening)
        {
            // Rotate the door to open
            door.rotation = Quaternion.Lerp(door.rotation, doorOpenRot, Time.deltaTime * rotateSpeed);

            // Stop the door when it has fully opened
            if (Quaternion.Angle(door.rotation, doorOpenRot) < 0.01f)
            {
                door.rotation = doorOpenRot;
                isOpening = false;
                hasOpened = true;
                hasClosed = false;
            }
        }
        else if (isClosing)
        {
            // Rotate the door to close
            door.rotation = Quaternion.Lerp(door.rotation, doorClosedRot, Time.deltaTime * rotateSpeed);

            // Stop the door when it has fully closed
            if (Quaternion.Angle(door.rotation, doorClosedRot) < 0.01f)
            {
                door.rotation = doorClosedRot;
                isClosing = false;
                hasOpened = false;  // Kapı kapandı, artık açılmış durumda değil
                hasClosed = true;
            }
        }
    }

    // Function to be called to open the door
    public void OpenDoor()
    {
        if (!isOpening && !isClosing && !hasOpened) 
        {
            isOpening = true;
            isClosing = false;
            isClosed = false;
            PlaySound();
        }
    }

    // Function to be called to close the door
    public void CloseDoor()
    {
        if (!isClosing && !isOpening && !hasClosed)
        {
            isOpening = false;
            isClosing = true;
            isClosed = true;
            PlaySound();
        }
    }
    
    public void CheckDoor()
    {
        if(!isClosed)
        {
            CloseDoor();
        }
    }

    // Function to play the door sound
    private void PlaySound()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
