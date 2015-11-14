using UnityEngine;
using System.Collections;

public class Branch : MonoBehaviour {
    #region Constants
    private const float MAX_BRANCH_STRENGTH = 10;
    private const float MIN_BRANCH_STRENGTH = 1;
    private const float COLOR_LERP = .02F;
    #endregion

    #region Private Variables
    private float colorToRed = 0;
    private float branchStrength = 0;
    #endregion

    #region Public Variables
    public bool wallBranch = false;
    public bool roofBranch = false;
    #endregion

    #region Unity Methods

    private void Start()
    {
        branchStrength = Random.Range(MIN_BRANCH_STRENGTH, MAX_BRANCH_STRENGTH);
    }

    private void FixedUpdate()
    {
        if (wallBranch || roofBranch)
        {
            ColorChange();
        }
    }

    #endregion
    #region Private Methods

    /// <summary>
    /// Makes a branch blink with a red color.
    /// </summary>
    private void ColorChange()
    {
        if ((int)(colorToRed % 2) == 0)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.red, COLOR_LERP);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.white, COLOR_LERP);
        }
        colorToRed += COLOR_LERP;
    }

    #endregion
}
