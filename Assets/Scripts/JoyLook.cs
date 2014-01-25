using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class JoyLook : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	public int playerNumber;

	private float currentX = 0;
	private float currentY = 0;

	void Update ()
	{
		Debug.Log(Input.GetAxis("Look1X") + ", " + Input.GetAxis("Look2X") + ", " + Input.GetAxis("Look1Y") + ", " + Input.GetAxis("Look2Y"));

		if (playerNumber == 1)
		{
			currentX += Input.GetAxis("Look1X") * sensitivityX;
			currentY += Input.GetAxis("Look1Y") * sensitivityY;
		}
		else if (playerNumber == 2)
		{
			currentX += Input.GetAxis("Look2X") * sensitivityX;
			currentY += Input.GetAxis("Look2Y") * sensitivityY;
		}
		transform.localEulerAngles = new Vector3(currentY, currentX, 0);
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		currentX = transform.localEulerAngles.x;
		currentY = transform.localEulerAngles.y;

		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
}

/*			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Look2Y") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);


*/


