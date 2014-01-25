using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    private const float WAIT_FOR_INPUT = 0.25f;

    private static InputManager _instance;

    private bool _isUp = false;
    private bool _isDown = false;

    private float time = 0;
    
    public static InputManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("InputManager").AddComponent<InputManager>();
            }

            return _instance;
        }
    }

	void Update ()
    {
        if (Input.GetAxisRaw("Vertical1") < 0)
        {
            _isDown = Time.time > time;
            _isUp = false;

            if (_isDown) time = Time.time + WAIT_FOR_INPUT;
        }
        else if (Input.GetAxisRaw("Vertical1") > 0)
        {
            _isDown = false;
            _isUp = Time.time > time;

            if (_isUp) time = Time.time + WAIT_FOR_INPUT;
        }
        else
        {
            _isUp = false;
            _isDown = false;
        }
	}

    public bool isUp
    {
        get { return _isUp; }
    }

    public bool isDown
    {
        get { return _isDown; }
    }
}
