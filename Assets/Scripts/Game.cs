using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	private Player player01;
    private Player player02;

    public World world01;
    public World world02;

    void Start()
    {
		player01 = GameObject.Find("Player1").GetComponent<Player>();//(GameObject.Instantiate(player01Prefab) as GameObject).GetComponent<Player>();
		player02 = GameObject.Find("Player2").GetComponent<Player>();//(GameObject.Instantiate(player02Prefab) as GameObject).GetComponent<Player>();

        player01.transform.parent = world01.transform;
        player02.transform.parent = world02.transform;

        //player01.transform.localPosition = world01.spawnPoint.localPosition;
        //player02.transform.localPosition = world02.spawnPoint.localPosition;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swapPlayers();
        }
    }

    private void swapPlayers()
    {
        Vector3 player01LocalPosition = player01.transform.localPosition;
        Vector3 player02LocalPosition = player02.transform.localPosition;

        Transform player01Parent = player01.transform.parent;
        Transform player02Parent = player02.transform.parent;

        player01.transform.parent = player02Parent;
        player02.transform.parent = player01Parent;

        player01.transform.localPosition = player02LocalPosition;
        player02.transform.localPosition = player01LocalPosition;
    }

    public void playerReachedEnd(Player player)
    {

    }
}