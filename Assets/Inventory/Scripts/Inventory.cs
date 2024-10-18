using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public TextMeshProUGUI itemName;

    public GameObject itemInfoPanel;

    // new input

    public int idInventory;

    public List<GameObject> slots = new();

    public GameObject select;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        select = EventSystem.current.currentSelectedGameObject;
    }

    public void SetMovement(InputAction.CallbackContext value)
    {
        Vector2 n = value.ReadValue<Vector2>();

        if (slots.Contains(select))
        {
            idInventory = select.GetComponent<Slot>().idSlot;
        }
        else
        {
            idInventory = slots.Count;
        }
    }

    public void OnClickSlot(int idSlot)
    {
        itemInfoPanel.SetActive(true);
    }

    public void OnEnterSlot(int idSlot)
    {
        itemName.enabled = true;
        itemName.text = idSlot.ToString();
    }

    public void OnExitSlot(int idSlot)
    {
        itemName.enabled = false;
        itemName.text = "";
    }
}
