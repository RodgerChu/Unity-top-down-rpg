using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{

    public Transform headItemPosition;
    public Transform bodyItemPosition;
    public Transform leftArmItemPosition;
    public Transform rightArmItemPosition;
    public Transform legsItemPosition;


    private Animator anim;
    private CharacterInventory inventory;

    private bool isSprinting = false;

    public readonly BaseState RunState = new RunState();
    public readonly BaseState SprintState = new SprintState();
    public readonly BaseState IdleState = new IdleState();
    public readonly BaseState MineState = new MineState();

    private BaseState currentState;

    private Vector3 lastPosition;
    private CharacterController charController;

    public PlayerEquipment equipment = new PlayerEquipment();
    public PlayerStatSystem statSystem;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start11!");
        anim = GetComponent<Animator>();
        inventory = GetComponent<CharacterInventory>();

        charController = GetComponent<CharacterController>();

        currentState = IdleState;
        lastPosition = transform.position;

        equipment.ItemEquipedEvent += HandleEquipItem;
        equipment.ItemUnequipedEvent += HandleUnequipItem;
    }



    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
        lastPosition = transform.position;
    }

    public void MoveTo(Vector3 position)
    {
        charController.Move(position);
        if (position.sqrMagnitude != 0)
        {
            anim.SetFloat("MovementSpeed", position.sqrMagnitude + 2);
        }
        else
        {
            anim.SetFloat("MovementSpeed", 0);
        }

    }

    public void TransitionToState(BaseState state)
    {
        Debug.Log("Moved from state " + currentState.ToString() + " to state " + state.ToString());
        currentState.OnStateExit(this);
        currentState = state;
        currentState.OnStateEnter(this);
    }

    public void StartMiningResource(ResourceSO resource, Vector3 position)
    {
        transform.LookAt(position);
        TransitionToState(MineState);
        if (MineState is MineState)
        {
            ((global::MineState)MineState).resourceToMine = resource;
        }
    }

    void StopAllActions()
    {
        TransitionToState(IdleState);
    }

    public bool AddToInventory(ItemSO item)
    {
        return inventory.AddToInventory(item);
    }

    public void RemoveFromInventory(EquipableItemSO item)
    {
        if (inventory.RemoveItem(item))
        {
            //do smth
        }
    }

    public bool IsMoving()
    {
        return lastPosition != transform.position;
    }

    public void StopMoving()
    {
        MoveTo(Vector3.zero);
    }

    public bool IsInventoryFull()
    {
        return inventory.IsInventoryFull();
    }

    public void StartMining()
    {
        StopMoving();
        anim.SetBool("Mining", true);
    }

    public void StopMining()
    {
        anim.SetBool("Mining", false);
    }

    public List<ItemSO> GetItems()
    {
        return inventory.GetItems();
    }

    private void HandleEquipItem(EquipableItemSO item)
    {
        StopAllActions();
        var itemPrefab = Instantiate(item.ItemPrefab);
        var itemPickUp = itemPrefab.GetComponent<PickUpItem>();
        var rigidBody = itemPrefab.GetComponent<Rigidbody>();

        inventory.RemoveItem(item);

        if (itemPickUp == null)
        {
            Debug.LogWarning("Equiped non-pickable item: " + item.ItemName);
        }
        else
        {
            Destroy(itemPickUp);
        }

        if (rigidBody == null)
        {
            Debug.LogWarning("Something wrong with item prefab: all items must contain rigidbody component");
        }
        else
        {
            rigidBody.isKinematic = true;
        }

        var itemPosition = item.ItemPosition;

        switch (itemPosition)
        {
            case ItemPositions.BODY:
                itemPrefab.transform.parent = bodyItemPosition;
                break;
            case ItemPositions.HEAD:
                itemPrefab.transform.parent = headItemPosition;
                break;
            case ItemPositions.LEGS:
                itemPrefab.transform.parent = legsItemPosition;
                break;
            case ItemPositions.LEFT_HAND:
                itemPrefab.transform.parent = leftArmItemPosition;
                break;
            case ItemPositions.BOTH_HANDS:
                itemPrefab.transform.parent = leftArmItemPosition;
                break;
            default:
                itemPrefab.transform.parent = rightArmItemPosition;
                break;
        }

        itemPrefab.transform.localPosition = Vector3.zero;
        itemPrefab.transform.localRotation = Quaternion.identity;
    }

    private void HandleUnequipItem(EquipableItemSO item)
    {
        StopAllActions();
        if (!inventory.AddToInventory(item)) { return; }
        Transform equipedItemTransform;
        var itemPosition = item.ItemPosition;
        switch (itemPosition)
        {
            case ItemPositions.BODY:
                equipedItemTransform = bodyItemPosition.GetChild(0);
                bodyItemPosition.DetachChildren();
                break;
            case ItemPositions.HEAD:
                equipedItemTransform = headItemPosition.GetChild(0);
                headItemPosition.DetachChildren();
                break;
            case ItemPositions.LEGS:
                equipedItemTransform = legsItemPosition.GetChild(0);
                legsItemPosition.DetachChildren();
                break;
            case ItemPositions.LEFT_HAND:
                equipedItemTransform = leftArmItemPosition.GetChild(0);
                leftArmItemPosition.DetachChildren();
                break;
            case ItemPositions.BOTH_HANDS:
                equipedItemTransform = leftArmItemPosition.GetChild(0);
                leftArmItemPosition.DetachChildren();
                rightArmItemPosition.DetachChildren();
                break;
            default:
                equipedItemTransform = rightArmItemPosition.GetChild(0);
                rightArmItemPosition.DetachChildren();
                break;
        }

        Destroy(equipedItemTransform.gameObject);
    }

    public void TranslateTo(Vector3 position)
    {
        var charComponent = GetComponent<CharacterController>();
        charComponent.enabled = false;
        gameObject.transform.position = position;
        charComponent.enabled = true;
    }

    public void StartBackgroundTask(IEnumerator courutine)
    {
        StartCoroutine(courutine);
    }

    public void StopBackgroundTask(IEnumerator courutine)
    {
        StopCoroutine(courutine);
    }
}
