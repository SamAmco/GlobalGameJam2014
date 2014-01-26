using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour
{
    public int messageID;

    private string[] messages = new string[3]
    {
        "Without thinking twice, I would have given anything to be able to put myself in her position.",
        "It used to drive me crazy,\nsometimes it felt like we were\nin two completely different\nworlds.",
        "Seriously, he would not\nlisten to anyone. If he only\nhad tried to look at the\nproblem from my point of\nview."
    };

    private Game game;

    public void init(Game game)
    {
        this.game = game;
    }

    public string message
    {
        get
        {
            return messages[messageID];
        }
    }
}
