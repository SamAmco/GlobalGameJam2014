using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Camera playerCamera;
    public TextMesh text;
    public int playerIndex;

    public GameObject noteImage;
    public TextMesh noteText;

    private bool isPOV = false;
    private Transform cameraTransform;
    private Vector3 cameraInitLocalPos;

    private Game game;

    public void init(Game game)
    {
        this.game = game;
        cameraInitLocalPos = playerCamera.transform.localPosition;
    }

    public void startCameraPOV(Transform otherCameraTransform)
    {
        isPOV = true;
        cameraTransform = otherCameraTransform;
    }

    public void endCameraPOV()
    {
        isPOV = false;
        cameraTransform = null;

        playerCamera.transform.localRotation = Quaternion.identity;
        playerCamera.transform.localPosition = cameraInitLocalPos;
    }

    void Update()
    {
        if (isPOV)
        {
            playerCamera.transform.position = cameraTransform.position;
            playerCamera.transform.rotation = cameraTransform.rotation;
        }
    }

    public void setText(string message)
    {
        if (text != null)
        {
            text.text = message;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Note")
        {
            Note note = other.GetComponent<Note>();
            readNote(note.message);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Note")
        {
            game.hasReadNote = true;
            hideNote();
        }
    }

    public void readNote(string message)
    {
        noteImage.SetActive(true);
        noteText.text = message;
    }

    public void hideNote()
    {
        noteImage.SetActive(false);
    }

    public void setInactive()
    {
        hideNote();
    }
}