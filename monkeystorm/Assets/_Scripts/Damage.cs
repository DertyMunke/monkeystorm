using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

    private enum dir { left, right, count};
    private float groundHeight = -8f;

    private void FixedUpdate()
    {
        if (transform.position.y < groundHeight)
        {
            HitTheGround();
        }
    }

    /// <summary>
    /// When the player falls to the ground this reverses the velocity to get him back on a branch.
    /// </summary>
    private void HitTheGround()
    {
        Vector2 vel = GetComponent<Rigidbody2D>().velocity;

        // When there's no x velocity this adds x velocity in a random direction,
        // so the player can grab a branch when there's no branch above them.
        if (vel.x == 0)
        {
            dir ran_dir = (dir)Random.Range(0, 2);
            if (ran_dir == dir.left)
                vel = new Vector2(-.5f, vel.y);
            else
                vel = new Vector2(.5f, vel.y);
        }

        GetComponent<Rigidbody2D>().velocity = -(vel * 1.2f);
    }
}
