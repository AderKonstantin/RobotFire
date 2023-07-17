using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform _robotPosition;
    void LateUpdate()
    {
        transform.position = _robotPosition.position;
    }
}
