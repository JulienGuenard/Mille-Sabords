using UnityEngine;
using TMPro;

public class UIManagerWinner : UIManagerHeritage
{
    public GameObject canvasWinner;
    public TextMeshProUGUI winnerText;

    public void Win(int playerNb)
    {
        canvasWinner.SetActive(true);
        string playerString = " ";

        if (playerNb == 0) playerString = "<color=#00B6FF>player one";
        if (playerNb == 1) playerString = "<color=#E7003A>player two";

        winnerText.text = playerString + "<color=#ffffff> is a winner !";
    }
}
