using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

    private const float MAX_Y = 4.2f;
    private const float MIN_Y = 1.22f;
    private const float MAX_X = 17.8f;
    private const float MIN_X = -17.75f;

    public Transform player;

    private void FixedUpdate ()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, MIN_X, MAX_X),
                Mathf.Clamp(player.position.y, MIN_Y, MAX_Y), transform.position.z);
    }
}
