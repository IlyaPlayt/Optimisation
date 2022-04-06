using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    Vector3 velocity;
    float sides = 30.0f;
    float speedMax = 0.3f;
    private string _propertyString = "_Color";
    private int _propertyID = -1;
    private Material _material;

    void Start()
    {
        velocity = new Vector3(Random.Range(0.0f, speedMax),
            Random.Range(0.0f, speedMax),
            Random.Range(0.0f, speedMax));
        _propertyID = Shader.PropertyToID(_propertyString);
        _material = GetComponent<Renderer>().material;
    }

    Color GetRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity);
        var position = transform.position;

        if (position.x > sides)
        {
            velocity.x = -velocity.x;
        }
        else if (position.x < -sides)
        {
            velocity.x = -velocity.x;
        }

        if (position.y > sides)
        {
            velocity.y = -velocity.y;
        }
        else if (position.y < -sides)
        {
            velocity.y = -velocity.y;
        }

        if (position.z > sides)
        {
            velocity.z = -velocity.z;
        }
        else if (position.z < -sides)
        {
            velocity.z = -velocity.z;
        }

       

        _material.SetColor(_propertyID, new Color(position.x / sides,
            position.y / sides,
            position.z / sides));
    }
}