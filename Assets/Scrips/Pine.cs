using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pine : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update() 
    {
        Move(); // tốc dộ ống chạy
    }
    private void Move() // gọi dựa trên FPS nên tốc độ phải nhân với deltatime = 1/FPS
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
