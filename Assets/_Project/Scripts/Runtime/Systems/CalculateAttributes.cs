using UnityEngine;

public class CalculateAttributes : MonoBehaviour
{
    //int,vector2,int
    // forca - dmgmelee,peso
    // destreza - dmgdistance e dodge

    //int,intbase,int,intbase
    //constituicao - hpmax,resfisica,resveneno
    //inteligencia - spmax,dmgmagic,resmagica

    public void SetForDex(int atr, ref Vector2 dmgParaAtualizar, ref int atrPlus, int atrBase)
    {
        switch (atr)
        {
            case 1:
                dmgParaAtualizar = Vector2.one;
                atrPlus = atrBase;
                break;
            case 2:
                dmgParaAtualizar = Vector2.one + new Vector2(0, 1);
                atrPlus = CalculateInt(atrBase, 5);
                break;
            case 3:
                dmgParaAtualizar = Vector2.one + new Vector2(1, 2);
                atrPlus = CalculateInt(atrBase, 10);
                break;
            case 4:
                dmgParaAtualizar = Vector2.one + new Vector2(2, 2);
                atrPlus = CalculateInt(atrBase, 15);
                break;
            case 5:
                dmgParaAtualizar = Vector2.one + new Vector2(2, 3);
                atrPlus = CalculateInt(atrBase, 20);
                break;
            case 6:
                dmgParaAtualizar = Vector2.one + new Vector2(3, 3);
                atrPlus = CalculateInt(atrBase, 25);
                break;
            case 7:
                dmgParaAtualizar = Vector2.one + new Vector2(3, 4);
                atrPlus = CalculateInt(atrBase, 30);
                break;
        }
    }

    public void SetInt(int atr, ref Vector2 dmgParaAtualizar, ref int atrPlus, int atrBase, ref int atrPlus2, int atrBase2)
    {
        switch (atr)
        {
            case 1:
                dmgParaAtualizar = Vector2.one;
                atrPlus = atrBase;
                atrPlus2 = atrBase2;
                break;
            case 2:
                dmgParaAtualizar = Vector2.one + new Vector2(0, 1);
                atrPlus = CalculateInt(atrBase, 5);
                atrPlus2 = CalculateInt(atrBase2, 5);
                break;
            case 3:
                dmgParaAtualizar = Vector2.one + new Vector2(1, 2);
                atrPlus = CalculateInt(atrBase, 10);
                atrPlus2 = CalculateInt(atrBase2, 10);
                break;
            case 4:
                dmgParaAtualizar = Vector2.one + new Vector2(2, 2);
                atrPlus = CalculateInt(atrBase, 15);
                atrPlus2 = CalculateInt(atrBase2, 15);
                break;
            case 5:
                dmgParaAtualizar = Vector2.one + new Vector2(2, 3);
                atrPlus = CalculateInt(atrBase, 20);
                atrPlus2 = CalculateInt(atrBase2, 20);
                break;
            case 6:
                dmgParaAtualizar = Vector2.one + new Vector2(3, 3);
                atrPlus = CalculateInt(atrBase, 25);
                atrPlus2 = CalculateInt(atrBase2, 25);
                break;
            case 7:
                dmgParaAtualizar = Vector2.one + new Vector2(3, 4);
                atrPlus = CalculateInt(atrBase, 30);
                atrPlus2 = CalculateInt(atrBase2, 30);
                break;
        }
    }

    public void SetCon(int atr, ref int atrPlus, int atrBase, ref int atrPlus2, int atrBase2, ref int atrPlus3, int atrBase3)
    {
        switch (atr)
        {
            case 1:
                atrPlus = atrBase;
                atrPlus2 = atrBase2;
                atrPlus3 = atrBase3;
                break;
            case 2:
                atrPlus = CalculateInt(atrBase, 5);
                atrPlus2 = CalculateInt(atrBase2, 5);
                atrPlus3 = CalculateInt(atrBase3, 5);
                break;
            case 3:
                atrPlus = CalculateInt(atrBase, 10);
                atrPlus2 = CalculateInt(atrBase2, 10);
                atrPlus3 = CalculateInt(atrBase3, 10);
                break;
            case 4:
                atrPlus = CalculateInt(atrBase, 15);
                atrPlus2 = CalculateInt(atrBase2, 15);
                atrPlus3 = CalculateInt(atrBase3, 15);
                break;
            case 5:
                atrPlus = CalculateInt(atrBase, 20);
                atrPlus2 = CalculateInt(atrBase2, 20);
                atrPlus3 = CalculateInt(atrBase3, 20);
                break;
            case 6:
                atrPlus = CalculateInt(atrBase, 25);
                atrPlus2 = CalculateInt(atrBase2, 25);
                atrPlus3 = CalculateInt(atrBase3, 25);
                break;
            case 7:
                atrPlus = CalculateInt(atrBase, 30);
                atrPlus2 = CalculateInt(atrBase2, 30);
                atrPlus3 = CalculateInt(atrBase3, 30);
                break;
        }
    }


    public int CalculateInt(int aBase, int value)
    {
        return aBase + value;
    }


}
