using UnityEngine;

public class Customization : MonoBehaviour
{
    public static Customization Instance;

    private GameManager gameManager;

    [Header("Custom")]
    public GameObject[] belt;
    public GameObject[] cloth;
    public ItemHead[] head;
    public GameObject[] skin;
    public GameObject[] glove;
    public GameObject[] hair;
    public GameObject[] hairHalf;
    public GameObject[] shoe;
    public GameObject[] shouder;

    [Header("Weapons")]
    public GameObject[] rightHand;
    public GameObject[] leftHand;

    private void Awake()
    {
        Instance = this;
        gameManager = GameManager.Instance;
    }

    public void SetHead()
    {
        foreach (GameObject h in hair)
        {
            h.SetActive(false);
        }

        foreach (GameObject h in hairHalf)
        {
            h.SetActive(false);
        }

        foreach (ItemHead h in head)
        {
            h.item.SetActive(false);
        }

        if (CheckIdEquip(gameManager.idHead, head))
        {
            head[gameManager.idHead].item.SetActive(true);

            switch (head[gameManager.idHead].hairType)
            {
                case HairType.Full:
                    if (CheckIdEquip(gameManager.idHair, hair))
                    {
                        hair[gameManager.idHair].SetActive(true);
                    }
                    break;
                case HairType.Half:
                    if (CheckIdEquip(gameManager.idHair, hair))
                    {
                        hairHalf[gameManager.idHair].SetActive(true);
                    }
                    break;
            }
        }
        else if (gameManager.idHead < 0)
        {
            if (CheckIdEquip(gameManager.idHair, hair))
            {
                hair[gameManager.idHair].SetActive(true);
            }
        }
    }

    public void SetBelt() // metodo da aula, seria um desse pra cada array
    {
        foreach (GameObject b in belt)
        {
            b.SetActive(false);
        }

        if (gameManager.idBelt >= 0 && gameManager.idBelt < belt.Length)
        {
            belt[gameManager.idBelt].SetActive(true);
        }
    }

    // meus metodos

    private bool CheckIdEquip<T>(int id, T[] equips)
    {
        return id >= 0 && id < equips.Length;
    }

    public void SetEquip(GameObject[] equip, int idEquip)
    {
        foreach (GameObject b in equip)
        {
            b.SetActive(false);
        }

        if (CheckIdEquip(idEquip, equip))
        {
            equip[idEquip].SetActive(true);
        }
    }
}
