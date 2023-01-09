using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ClawState
{
    Open,
    Closed
}

public enum PositionState
{
    Idle,
    Descend,
    AutoMove,
    Rise,
    Waiting
}


public class ClawController : MonoBehaviour
{
    private ClawState _clawState;
    private PositionState _positionState;
    private Rigidbody rb;
    private Camera cam;
    public bool move = false;
    private Vector3 defaultPosition;

    private int horizontalDir, verticalDir = 1;

    private float moveSpeed = 0.2f;
    private float riseSpeed = 0.2f;

    public List<Transform> arms;

    private Coroutine currentCoroutine;
    private Coroutine movementCoroutine;

    private List<Vector3> startRot = new List<Vector3>();

    public List<GameObject> collidersToDisable;


    private Controls controls;

    private InputAction moveAction;

    private void Awake()
    {
        controls = new Controls();
        moveAction = controls.Claw.Move;
        controls.Claw.Descend.performed += _ =>
        {
            if (_clawState == ClawState.Open && _positionState == PositionState.Idle)
                ChangePositionState(PositionState.Descend);
        };
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {

        //StartCoroutine(WaitForObjectSpawns());

        rb = GetComponent<Rigidbody>();
        cam = Camera.main;

        _clawState = ClawState.Open;
        ChangePositionState(PositionState.Idle);
        defaultPosition = transform.position;

        foreach (var arm in arms)
        {
            startRot.Add(arm.localEulerAngles);
        }


    }

    IEnumerator WaitForObjectSpawns()
    {
        foreach (var col in collidersToDisable)
        {
            col.GetComponent<Collider>().enabled = false;
        }

        yield return new WaitForSeconds(2f);

        foreach (var col in collidersToDisable)
        {
            col.GetComponent<Collider>().enabled = true;
        }

    }

    private void ChangeState(ClawState state)
    {
        if (_clawState == state)
            return;

        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        switch (state)
        {
            case ClawState.Open:
                currentCoroutine = StartCoroutine(OpenClawCoroutine());
                break;

            case ClawState.Closed:
                currentCoroutine = StartCoroutine(CloseClawCoroutine());
                break;
        }

    }


    private void ChangePositionState(PositionState state)
    {

        if (movementCoroutine != null)
            StopCoroutine(movementCoroutine);

        switch (state)
        {

            case PositionState.Descend:
                movementCoroutine = StartCoroutine(DescendClawCoroutine());
                break;

            case PositionState.Rise:
                movementCoroutine = StartCoroutine(RiseClawCoroutine());
                break;

            case PositionState.Idle:
                movementCoroutine = StartCoroutine(CheckMovementInput());
                break;

            case PositionState.AutoMove:
                movementCoroutine = StartCoroutine(AutoMoveCoroutine());
                break;


        }

        _positionState = state;
    }

    #region ClawStateCoroutines

    IEnumerator CheckMovementInput()
    {
        yield return null;
        while(_positionState == PositionState.Idle)
        {
            var direction = moveAction.ReadValue<Vector2>();
            var horizontal = direction.x * cam.transform.right;
            var vertical = direction.y * cam.transform.forward;
            Vector3 move = new Vector3(horizontal.x + vertical.x, 0, vertical.z + vertical.z);
            rb.MovePosition(transform.position + move * Time.deltaTime * moveSpeed);
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator CloseClawCoroutine()
    {
        bool[] isDone = new bool[3];

        do
        {
            for (int i = 0; i < arms.Count; i++)
            {
                var targetRot = Quaternion.Euler(new Vector3(startRot[i].x - 50, startRot[i].y, startRot[i].z));
                arms[i].localRotation = Quaternion.RotateTowards(arms[i].transform.localRotation, targetRot, 0.1f);

                if (arms[i].transform.localEulerAngles.Equals(targetRot.eulerAngles))
                    isDone[i] = true;

            }

            yield return null;
        } while (!isDone[0] || !isDone[1] || !isDone[2]);


        _clawState = ClawState.Closed;
        EventManager.instance.InvokeEvent(EventEnums.CLAW_ON_CLAW_CLOSED);
        currentCoroutine = null;
    }

    IEnumerator OpenClawCoroutine()
    {
        bool[] isDone = new bool[3];

        do
        {
            for (int i = 0; i < arms.Count; i++)
            {
                var targetRot = Quaternion.Euler(new Vector3(startRot[i].x, startRot[i].y, startRot[i].z));
                arms[i].localRotation = Quaternion.RotateTowards(arms[i].transform.localRotation, targetRot, 0.1f);

                if (arms[i].transform.localEulerAngles.Equals(targetRot.eulerAngles))
                    isDone[i] = true;

            }

            yield return null;
        } while (!isDone[0] || !isDone[1] || !isDone[2]);


        _clawState = ClawState.Open;
        EventManager.instance.InvokeEvent(EventEnums.CLAW_ON_CLAW_OPENED);
        currentCoroutine = null;
    }

    #endregion

    #region PositionStateCoroutines
    IEnumerator AutoMoveCoroutine()
    {

        //open boundary

        //move to drop zone

        bool onDropzone = false;
        EventManager.instance.AddListenerOnce(EventEnums.CLAW_FINISH_MOVE_TO_DROP_ZONE, (x) => onDropzone = true);

        //SpawnManager.instance.DisableSplitterBoundary();
        var targetPos = SpawnManager.instance.dropzoneEndpoint.transform.position;

        while (!onDropzone)
        {
            Vector3 move = new Vector3(targetPos.x - transform.position.x, 0, targetPos.z - transform.position.z).normalized;
            rb.MovePosition(transform.position + move * Time.deltaTime * moveSpeed);
            yield return new WaitForFixedUpdate();
        };




        //open claw
        bool clawOpened = false;
        EventManager.instance.AddListenerOnce(EventEnums.CLAW_ON_CLAW_OPENED, (x) => { clawOpened = true; });
        ChangeState(ClawState.Open);

        while (!clawOpened)
        {
            yield return new WaitForFixedUpdate();
        }


        yield return new WaitForSeconds(1f);


        //back to start zone
        bool isBackOnStart = false;


        while (!isBackOnStart)
        {

            Vector3 moveToStart = new Vector3(defaultPosition.x - transform.position.x, 0, defaultPosition.z - transform.position.z).normalized;

            if ((defaultPosition - transform.position).magnitude <= 0.01f)
            {
                isBackOnStart = true;
            }

            rb.MovePosition(transform.position + moveToStart * Time.deltaTime * moveSpeed);
            yield return new WaitForFixedUpdate();
        }


        //close back boundary
        //SpawnManager.instance.EnableSplitterBoundary();


        yield return new WaitForFixedUpdate();
        ChangePositionState(PositionState.Idle);
    }



    IEnumerator DescendClawCoroutine()
    {
        EventManager.instance.AddListenerOnce(EventEnums.CLAW_COLLIDER_COLLISION_ENTER, (x) =>
        {
            if (_positionState != PositionState.Descend && _positionState != PositionState.Waiting)
                return;

            ChangePositionState(PositionState.Waiting);
            ChangeState(ClawState.Closed);
            EventManager.instance.AddListenerOnce(EventEnums.CLAW_ON_CLAW_CLOSED, (_) => { ChangePositionState(PositionState.Rise); });
        });
        yield return null;
        
        while (_positionState == PositionState.Descend)
        {
            rb.MovePosition(transform.position + Vector3.down * Time.deltaTime * riseSpeed);
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator RiseClawCoroutine()
    {
        yield return null;
        while (_positionState == PositionState.Rise)
        {
            if (transform.position.y >= defaultPosition.y)
            {
                ChangePositionState(PositionState.AutoMove);
                break;
            }
            else rb.MovePosition(transform.position + Vector3.up * Time.deltaTime * riseSpeed);

            yield return new WaitForFixedUpdate();
        }

    }

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CabinetEdge"))
        {
            //open claw and
            EventManager.instance.InvokeEvent(EventEnums.CLAW_FINISH_MOVE_TO_DROP_ZONE);
        }
    }



}
