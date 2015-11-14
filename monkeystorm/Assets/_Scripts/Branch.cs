using UnityEngine;
using System.Collections;

public class Branch : MonoBehaviour {

    private const float MAX_BRANCH_STRENGTH = 10;
    private const float MIN_BRANCH_STRENGTH = 1;   
    private float branchStrength = 0;

    public bool wallBranch = false;
    public bool roofBranch = false;

    private void Start()
    {
        branchStrength = Random.Range(MIN_BRANCH_STRENGTH, MAX_BRANCH_STRENGTH);
    }

    private void Update()
    {

    }

}
