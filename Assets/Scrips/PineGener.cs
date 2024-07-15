using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PineGener : MonoBehaviour
{
    public GameObject pinePerfabs;

    private float countdown; // check thời gian sinh ống
    public float timeDuration; // thời gian giữa 2 lần sinh ống
    public bool agreeGener = false;
    private void Awake()
    {
        countdown = -0.5f;
    }
    // Update is called once per frame
    void Update()
    {
        if (agreeGener == true) // đồng ý bắt đầu sinh ống
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                
                // sinh ống
                Instantiate(pinePerfabs, new Vector3(10, Random.Range(-2f, 2f), 0), Quaternion.identity);
                countdown = timeDuration;
            }
        }
    }
}
