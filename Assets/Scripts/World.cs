using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
    public Transform spawnPoint;
    public EndOfLevel endOfLevel;

    public void init(Game game)
    {
        endOfLevel.init(game);
    }
}