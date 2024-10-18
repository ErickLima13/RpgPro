using UnityEngine;

public class Slot : MonoBehaviour
{
    public int idSlot;

    private void Update()
    {
        if (Inventory.Instance.idInventory != idSlot)
        {
            return;
        }

        if (Inventory.Instance.select == gameObject)
        {
            OnEnterSlot();
        }
        else
        {
            OnExitSlot();
        }

    }

    public void OnClickSlot()
    {
        Inventory.Instance.OnClickSlot(idSlot);
    }

    public void OnExitSlot()
    {
        Inventory.Instance.OnExitSlot(idSlot);
    }

    public void OnEnterSlot()
    {
        Inventory.Instance.OnEnterSlot(idSlot);

    }

}
