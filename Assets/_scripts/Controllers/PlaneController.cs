using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] PlanePiece piece;
    PlanePiece[] pieces;

    public bool IsOff(PlanePiece planePiece)
    {
        pieces = GetComponentsInChildren<PlanePiece>();
        if (pieces.Length > 0 && pieces[0] == planePiece)
        {
            SpawnPlanePiece();
            return true;
        }
        return false;
    }

    void SpawnPlanePiece()
    {
        Transform last = pieces[pieces.Length - 1].transform;
        Instantiate(piece, last.position + new Vector3(last.lossyScale.x / 2 + piece.transform.lossyScale.x / 2, 0, 0), Quaternion.identity, transform);
    }
}
