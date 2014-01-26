using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject title;
    public GameObject levelSelector;

	void Start ()
    {
        title.SetActive(true);
        levelSelector.SetActive(false);
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("Action1") || Input.GetButtonDown("Action2"))
        {
            title.SetActive(false);
            levelSelector.SetActive(true);
        }
	}
}