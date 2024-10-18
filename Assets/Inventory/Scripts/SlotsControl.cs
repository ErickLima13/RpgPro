using UnityEngine;
using UnityEngine.EventSystems;

public class SlotsControl : MonoBehaviour
{
    public GameObject prefabSlot;
    public int columnsCount;
    public int rowsCount;

    private void Start()
    {
        CreateNewSlot(columnsCount,rowsCount);
    }

    public void CreateNewSlot(int columns,int rows)
    {
        for (int i = 0; i < columns * rows; i++)
        {
            GameObject g = Instantiate(prefabSlot, transform);
            g.name = "slot " + i.ToString();
              
            GameObject c = g.transform.GetChild(0).gameObject;
            c.name = "item " + i.ToString();
            c.GetComponent<Slot>().idSlot = i;

            Inventory.Instance.slots.Add(c);
        }
    }
}
