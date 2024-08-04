using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovementSpeedAffect
{
    [SerializeField] private float _movementSpeed, _rotationSpeed;
    private Rigidbody _rb;
    private Vector3 _input;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Move();
        Look();
    }

    private void Look()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new (Vector3.up, transform.position);       

        if (playerPlane.Raycast(ray, out float hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            targetPoint.y = transform.position.y;
            Vector3 directionToMouse = targetPoint - transform.position;
            float targetAngle = Mathf.Atan2(directionToMouse.x, directionToMouse.z) * Mathf.Rad2Deg;
            float currentAngle = transform.eulerAngles.y;
            float angle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, _rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }

    private void Move()
    {
        _rb.velocity = _input * _movementSpeed;
    }

    public void AffectOnSpeed(float speedChanger)
    {
        _movementSpeed *= speedChanger;
    }
}
