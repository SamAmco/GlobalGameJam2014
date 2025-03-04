using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class JoyLook : MonoBehaviour
{
	private float sensitivityX = 5.0f;
    private float sensitivityY = 5.0f;

    private float minimumY = -60.0f;
    private float maximumY = 60.0f;

	public int playerNumber;

	private float currentX = 0;
	private float currentY = 0;

    private bool isInPOV = false;

	void Update ()
	{
		if (playerNumber == 1)
		{
			currentX += Input.GetAxis("Look1X") * sensitivityX;
            if (!isInPOV) currentY += Input.GetAxis("Look1Y") * sensitivityY;
		}
		else if (playerNumber == 2)
		{
			currentX += Input.GetAxis("Look2X") * sensitivityX;
            if (!isInPOV) currentY += Input.GetAxis("Look2Y") * sensitivityY;
		}

        currentY = Mathf.Clamp(currentY, minimumY, maximumY);
		transform.localEulerAngles = new Vector3(currentY, currentX, 0);
	}
	
	void Start ()
	{
        currentX = transform.localEulerAngles.y;
	}

    public void startPOV()
    {
        isInPOV = true;
        currentY = 0;
    }

    public void endPOV()
    {
        isInPOV = false;
    }
}
