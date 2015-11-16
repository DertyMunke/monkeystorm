using UnityEngine;
using System.Collections;

public class Bananas : MonoBehaviour {

    private int maxNumBananas = 10;
    private int numAvailableBananas = 0;

    public static Bananas bananaScript;
    public GameObject[] spawnPts = new GameObject[51];
    public GameObject[] bananas = new GameObject[2];

    private void Start()
    {
        bananaScript = this;

        for(int i = 0; i < maxNumBananas; i++)
        {
            GrowBanana();
        }
    }

    /// <summary>
    /// Grows a random banana object (1 or 3) in a random position
    /// </summary>
    private void GrowBanana()
    {
        int numBans = Random.Range(0, 100) % 4 == 0 ? 1 : 0;
        
        Instantiate(bananas[numBans], spawnPts[Random.Range(0, 51)].transform.position, Quaternion.identity);
        numAvailableBananas++;
    }

    /// <summary>
    /// Subtracts the numConsumed amount of bananas from the number of available bananas 
    /// </summary>
    /// <param name="numConsumed"></param>
    public void ConsumeBanana(int numConsumed = 1)
    {
        numAvailableBananas -= numConsumed;
        Invoke("GrowBanana", Random.Range(0, 3f));
    }

    
}
