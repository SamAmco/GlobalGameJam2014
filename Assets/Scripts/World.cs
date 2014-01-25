using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
    public Gem gem;
    public Note note;

    public void init(Game game)
    {
        gem.init(game);
        note.init(game);
    }

    public void setItemsActive(bool isActive)
    {
        gem.gameObject.SetActive(isActive);
        note.gameObject.SetActive(isActive);
    }
}