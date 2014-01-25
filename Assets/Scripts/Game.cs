using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	private Player player01;
    private Player player02;

    public World world01;
    public World world02;

    private bool isPlayer01InPOV = false;
    private bool isPlayer02InPOV = false;

    void Start()
    {
		player01 = GameObject.Find("Player1").GetComponent<Player>();
		player02 = GameObject.Find("Player2").GetComponent<Player>();

        player01.transform.parent = world01.transform;
        player02.transform.parent = world02.transform;

        player01.transform.localPosition = world01.spawnPoint.localPosition;
        player02.transform.localPosition = world02.spawnPoint.localPosition;
    }

    void Update()
    {
        if (Input.GetButtonDown("Action1") || Input.GetButtonDown("Action2"))
        {
            //swapPosition();
            //swapWorld();

            if (Input.GetButtonDown("Action1"))
            {
                swapPOV(isPlayer01InPOV, player01, player02, world01, world02);
                isPlayer01InPOV = !isPlayer01InPOV;
            }
            else
            {
                swapPOV(isPlayer02InPOV, player02, player01, world02, world01);
                isPlayer02InPOV = !isPlayer02InPOV;
            }
        }
    }

    private void swapPosition()
    {
        Vector3 player01LocalPosition = player01.transform.localPosition;
        Vector3 player02LocalPosition = player02.transform.localPosition;

        player01.transform.localPosition = player02LocalPosition;
        player02.transform.localPosition = player01LocalPosition;
    }

    private void swapWorld()
    {
        Vector3 player01LocalPosition = player01.transform.localPosition;
        Vector3 player02LocalPosition = player02.transform.localPosition;

        Transform player01Parent = player01.transform.parent;
        Transform player02Parent = player02.transform.parent;

        player01.transform.parent = player02Parent;
        player02.transform.parent = player01Parent;

        player01.transform.localPosition = player01LocalPosition;
        player02.transform.localPosition = player02LocalPosition;
    }

    public void swapPOV(bool isInPOV, Player player, Player otherPlayer, World world, World otherWorld)
    {
        if (isInPOV)
        {
            player.endCameraPOV();

            Vector3 playerLocalPosition = player.transform.localPosition;

            player.transform.parent = world.transform;
            player.transform.localPosition = playerLocalPosition;
        }
        else
        {
            player.startCameraPOV(otherPlayer.playerCamera.transform);

            Vector3 player01LocalPosition = player.transform.localPosition;

            player.transform.parent = otherWorld.transform;
            player.transform.localPosition = player01LocalPosition;
        }
    }

    public void playerReachedEnd(Player player)
    {

    }
}