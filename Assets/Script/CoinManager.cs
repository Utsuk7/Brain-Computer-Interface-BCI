using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int coinCount;
    public Text coinText;
    /*void Start()
    {
        
    }
*/
    // Update is called once per frame
    void Update()
    {
        coinText.text=coinCount.ToString();
    }
}
