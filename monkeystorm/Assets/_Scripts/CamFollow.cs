using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour{

    private void FixedUpdate()
    {
        //Mathf.Clamp(..y, 1.22f, 4.2f);
        Debug.Log(transform.position.y);
    }
}
