using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
    public Transform spawnPoint;
    public Gem endOfLevel;

    public void init(Game game)
    {
        endOfLevel.init(game);
    }

    public void setGemActive(bool isActive)
    {
        endOfLevel.gameObject.SetActive(isActive);
    }
}