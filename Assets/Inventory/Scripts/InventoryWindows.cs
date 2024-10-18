using UnityEngine;
using UnityEngine.UI;

public class InventoryWindows : MonoBehaviour
{
    public Sprite[] imageTab;

    public Image[] tabs;

    public GameObject[] contents;

    public int idTabActive;


    private void Start()
    {
        SelectTab(idTabActive);
    }

    public void SelectTab(int idTab)
    {
        Inventory.Instance.itemInfoPanel.SetActive(false);

        foreach (Image i in tabs)
        {
            i.sprite = imageTab[0];
        }

        foreach (GameObject g in contents)
        {
            g.SetActive(false);
        }

        tabs[idTab].sprite = imageTab[1];
        contents[idTab].SetActive(true);
    }
}
