using UnityEngine;
using System.Collections;

public class LevelSelector : MonoBehaviour
{
    private int currentLevelIndex;
    private int numLevels;

    public TextMesh[] levels;

    void OnEnable()
    {
        currentLevelIndex = 0;

        levels[0].color = Color.white;
        levels[1].color = Color.grey;
        levels[2].color = Color.grey;

        numLevels = levels.Length - 1;
    }

	void Update ()
    {
	    if (InputManager.instance.isUp)
        {
            levels[currentLevelIndex].color = Color.grey;

            currentLevelIndex--;
            if (currentLevelIndex < 0) currentLevelIndex = 0;

            levels[currentLevelIndex].color = Color.white;
        }
        else if (InputManager.instance.isDown)
        {
            levels[currentLevelIndex].color = Color.grey;

            currentLevelIndex++;
            if (currentLevelIndex > numLevels) currentLevelIndex = numLevels;

            levels[currentLevelIndex].color = Color.white;
        }

        Debug.Log(currentLevelIndex);
	}
}
