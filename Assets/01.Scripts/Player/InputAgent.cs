using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputAgent : MonoBehaviour
{
    public UnityEvent<Vector3, bool> OnMovementEvent;
    public UnityEvent<Vector3> OnMousePositionEvent;
    public UnityEvent OnAttackKeyPress = null;

    public bool IsRolling;

    private Vector3 vec;

    private void Update()
    {
        OnMovement();
        MousePoistion();
        UpdateAttackInput();
    }

    private void OnMovement()
    {
        float horizontal = IsRolling ? Input.GetAxis("Horizontal") : Input.GetAxisRaw("Horizontal");
        float vertical = IsRolling ? Input.GetAxis("Vertical") : Input.GetAxisRaw("Vertical");

        OnMovementEvent?.Invoke(new Vector3(horizontal, 0, vertical), IsRolling);
    }
    private void UpdateAttackInput()
    {
        if (Input.GetMouseButton(0) && IsRolling == false)
        {
            OnAttackKeyPress?.Invoke();
        }
    }

    private void MousePoistion()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitResult;

        if(Physics.Raycast(ray, out hitResult))
        {
            vec = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            transform.forward = vec;
            OnMousePositionEvent?.Invoke(vec);
        }

    }
}
