using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneMover : MonoBehaviour
{
    public float speed;
    public float start;
    public float end;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x <= end)
        {
            transform .position = new Vector2(start, transform.position.y);
        }
    }
}
