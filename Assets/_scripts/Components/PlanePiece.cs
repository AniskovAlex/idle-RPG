using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePiece : MonoBehaviour
{
    float speed = 1;
    PlaneController controller;
    private void Start()
    {
        controller = GetComponentInParent<PlaneController>();
        speed = GlobaleStatus.GetSpeed();
    }

    private void Update()
    {
        if (GlobaleStatus.GetState() == GlobaleStatus.StatePos.stay) return;
        transform.position += (Vector3.left * speed) * Time.deltaTime;
    }
    private void OnBecameInvisible()
    {
        if (controller == null) return;
        if (controller.IsOff(this))
            Destroy(gameObject);
    }
}
