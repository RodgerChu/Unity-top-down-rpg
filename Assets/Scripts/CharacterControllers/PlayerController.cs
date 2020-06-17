using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{ 
    private Animator anim;
    private CharacterInventory inventory;

    private bool isSprinting = false;

    public readonly BaseState RunState = new RunState();
    public readonly BaseState SprintState = new SprintState();
    public readonly BaseState IdleState = new IdleState();
    private BaseState currentState;

    private Vector3 lastPosition;       

    private CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start11!");
        anim = GetComponent<Animator>();
        inventory = GetComponent<CharacterInventory>();

        charController = GetComponent<CharacterController>();

        currentState = IdleState;
        lastPosition = transform.position;
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
        Debug.Log("Moved from state " + currentState.ToString()  + " to state " + state.ToString());
        currentState.OnStateExit(this);
        currentState = state;
        currentState.OnStateEnter(this);       
    }

    void StopAllActions()
    {
        currentState = IdleState;
    }

    public bool AddToInventory(ItemSO item)
    {
        return inventory.AddToInventory(item);
    }

    public void RemoveFromInventory(ItemSO item)
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

    public List<ItemSO> GetItems()
    {
        return inventory.GetItems();
    }


    #region Old Commented Code

    // -------- UPDATE -------
    //if (agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance <= 0.1f)
    //{
    //    agent.SetDestination(transform.position);
    //    anim.SetFloat("MovementSpeed", 0);
    //    if (gameObject != null)
    //    {
    //        if (gameObject.tag == "MineableOre")
    //        {
    //            if (handledTool?.tag == "Pickaxe")
    //            {
    //                anim.SetBool("Mining", true);
    //            }                    
    //        }
    //        else if (gameObject.tag == "Pickaxe")
    //        {
    //            GrabTool(gameObject);
    //        }
    //        gameObject = null;
    //    }            
    //}
    //else
    //{
    //    float speed = 0f;
    //    speed = Vector3.Project(agent.desiredVelocity, transform.forward).magnitude;
    //    anim.SetFloat("MovementSpeed", speed);
    //}

    //var currentMoveSpeed = agent.velocity.sqrMagnitude;
    //anim.SetFloat("MovementSpeed", currentMoveSpeed);

    //if (agent.pathStatus == NavMeshPathStatus.PathComplete)
    //{
    //    if (gameObject != null)
    //    {
    //        if (gameObject.tag == "MineableOre")
    //        {
    //            if (handledTool?.tag == "Pickaxe")
    //            {
    //                anim.SetBool("Mining", true);
    //            }
    //        }
    //        else if (gameObject.tag == "Pickaxe")
    //        {
    //            GrabTool(gameObject);
    //        }
    //        gameObject = null;
    //    }
    //}


    //if (Input.GetKeyDown(KeyCode.Alpha1))
    //{
    //    if (handledTool != null && backTool == null)
    //    {
    //        handledTool.transform.parent = null;
    //        GrabTool(handledTool);
    //        handledTool = null;
    //    } else if (backTool != null && handledTool == null)
    //    {
    //        backTool.transform.parent = null;
    //        EquipTool(backTool);
    //        backTool = null;
    //    }
    //}

    //var hInp = Input.GetAxis("Vertical");
    //var vInp = Input.GetAxis("Horizontal");
    //var userInput = new Vector3(vInp, 0, hInp);

    //if (userInput != Vector3.zero)
    //{
    //    isSprinting = Input.GetKeyDown(KeyCode.LeftShift);
    //    var cameraForward = Camera.main.transform.forward;
    //    cameraForward.y = 0;

    //    var cameraRelativeRotation = Quaternion.FromToRotation(Vector3.forward, cameraForward);
    //    var lookForward = cameraRelativeRotation * userInput;

    //    var lookRay = new Ray(transform.position, lookForward);
    //    transform.LookAt(lookRay.GetPoint(1));

    //    if (isSprinting)
    //    {
    //        userInput *= 1.5f;
    //    }

    //    charController.Move(userInput / 13);
    //    anim.SetFloat("MovementSpeed", userInput.sqrMagnitude + 2);
    //} else
    //{
    //    charController.Move(Vector3.zero);
    //    anim.SetFloat("MovementSpeed", 0);
    //}
    // -------- END UPDATE -------



    //private void onClick(ClickData clickData)
    //{
    //    if (clickData.clickedLMB)
    //    {
    //        StopAllActions();
    //        var numOfClicks = clickData.numOfClicks;
    //        var location = clickData.clickArea;
    //        gameObject = clickData.clickedObject;
    //        agent.destination = location;
    //        var speed = 0f;

    //        if (numOfClicks == 1)
    //        {
    //            speed = walkMoveSpeed;
    //        }
    //        else
    //        {
    //            speed = runMoveSpeed;
    //        }

    //        agent.speed = speed;
    //        anim.SetFloat("MovementSpeed", speed);
    //    }
    //    else
    //    {
    //        handledTool.transform.parent = null;
    //        var rigidBodyComponent = handledTool.GetComponent<Rigidbody>();
    //        rigidBodyComponent.isKinematic = false;
    //        //var currentPos = handledTool.transform.position;
    //        //handledTool.transform.position = new Vector3(currentPos.x, 0.566f, currentPos.z);
    //        handledTool = null;
    //    }        
    //}

    //void GrabTool(GameObject tool)
    //{
    //    Debug.Log("Grab tool");
    //    if (backTool == null)
    //    {
    //        Debug.Log("Grabbing");
    //        tool.transform.parent = backToolPosition;
    //        tool.transform.position = backToolPosition.position;
    //        var rigidBodyComponent = tool.GetComponent<Rigidbody>();
    //        rigidBodyComponent.isKinematic = true;

    //        tool.transform.rotation = backToolPosition.rotation;
    //        tool.transform.Rotate(50, 0, 0);
    //    }

    //}

    //void EquipTool(GameObject tool)
    //{
    //    tool.transform.parent = toolPosition;
    //    tool.transform.position = toolPosition.position;
    //    var rigidBodyComponent = tool.GetComponent<Rigidbody>();
    //    rigidBodyComponent.isKinematic = true;

    //    tool.transform.rotation = toolPosition.rotation;
    //    tool.transform.Rotate(180, 0, 0);

    //    handledTool = tool;
    //}

    #endregion
}
