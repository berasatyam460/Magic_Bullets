using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_follow : MonoBehaviour
{

    public Transform playerTransform;
    public float speed;
    public float minX;
    public float maxX; 
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerTransform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {

            float clamedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clamedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);

            transform.position = Vector2.Lerp(transform.position, new Vector2 (clamedX,clamedY), speed);
        }
    }
}
