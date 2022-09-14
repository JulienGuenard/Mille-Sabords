using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerIncrement : ScoreManagerHeritage
{
    List<int> comboList = new List<int>();
    int chestCombo;

    public int GetChestCombo() { return chestCombo; }
    public void SetChestCombo(int value) { chestCombo = value; }
    public void AddChestCombo(int value) { chestCombo += value; }

    public void ResetCombo()
    {

        comboList = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            comboList.Add(0);
        }
    }

    public void CorsairCombo(int count)
    {
        ScoreManager.instance.SetScore(-100 * count);
    }

    public void NewScoreCumulFaces(List<DiceFace> resultDiceFaceList)
    {
        foreach (DiceFace d in resultDiceFaceList)
        {
            switch (d)
            {
                case DiceFace.Coin:
                    ScoreManager.instance.AddScore(100);
                    comboList[0]++;
                    AddChestCombo(1);
                    break;
                case DiceFace.Diamond:
                    ScoreManager.instance.AddScore(100);
                    comboList[1]++;
                    AddChestCombo(1);
                    break;
                case DiceFace.Swords:
                    comboList[2]++;
                    break;
                case DiceFace.Perroquet:
                    comboList[3]++;
                    break;
                case DiceFace.Monkey:
                    comboList[4]++;
                    break;
            }
        }
    }

    public void NewScoreIncrement()
    {
        for (int i = 0; i < 5; i++)
        {
            switch (comboList[i])
            {
                case 3: ScoreManager.instance.AddScore(100); break;
                case 4: ScoreManager.instance.AddScore(200); break;
                case 5: ScoreManager.instance.AddScore(500); break;
                case 6: ScoreManager.instance.AddScore(1000); break;
                case 7: ScoreManager.instance.AddScore(2000); break;
                case 8: ScoreManager.instance.AddScore(4000); break;
            }

            if (i >= 2)
            {
                if (comboList[i] >= 3) AddChestCombo(comboList[i]);
            }
        }

        if (GetChestCombo() == 8) ScoreManager.instance.AddScore(500);
    }
}
