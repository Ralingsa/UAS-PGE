using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camCtrl : MonoBehaviour
{
    public Transform target;
    public Transform bg1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y != transform.position.y && target.position.y > 0 && target.position.y < 3f && target.position != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,
                target.position.y, transform.position.z), 0.1f);

        }

        bg1.transform.position = new Vector2(bg1.transform.position.x, transform.position.y * 1.2f);
    }
}
