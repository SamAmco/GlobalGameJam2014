using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour
{
    public Transform cube;

    private Game game;

    public void init(Game game)
    {
        this.game = game;
    }

	void Update ()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * 100);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            game.playerReachedEnd(player);
        }
    }
}