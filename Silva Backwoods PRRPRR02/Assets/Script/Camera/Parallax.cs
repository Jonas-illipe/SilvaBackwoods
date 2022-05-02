using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    public float yFollow;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

       // float temp2 = (cam.transform.position.y * (1 - parallaxEffect));
        //float dist2 = (cam.transform.position.y * parallaxEffect);
        //transform.position = new Vector3(transform.position.x, startpos + dist2, transform.position.z);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
        /*
        if (temp2 > startpos + length) startpos += length;
        else if (temp2 < startpos - length) startpos -= length;*/
    }
}