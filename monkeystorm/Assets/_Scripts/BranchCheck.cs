﻿using UnityEngine;
using System.Collections;

public class BranchCheck : MonoBehaviour {

    private GameObject currentBranch;

    public static BranchCheck branchCheckScript;

    public GameObject CurrentBranch { get { return currentBranch; } }

    private void Awake()
    {
        branchCheckScript = this;
    }

    /// <summary>
    /// When the monkey passes through a branch, activate the collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Branch")
            GetComponent<Collider2D>().isTrigger = false;
    }

    /// <summary>
    /// Keep track of the current branch that the monkey is holding on to
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Branch")
            currentBranch = other.gameObject;
    }
}
