using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForCamera : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private void Update()
    {
        transform.position = target.transform.position + new Vector3(0, 20.0f, -7.0f);
    }
}
