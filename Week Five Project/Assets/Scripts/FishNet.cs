using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishNet : MonoBehaviour
{
    private float rotateNet = 10;
    private float maxRotation = 80;
    private bool rotate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            //everytime you press E, the net moves accordingly
            if (Input.GetKeyDown(KeyCode.E))
            {
                rotate = true;
            }

            if (rotate) //roating the net, but only to its max
            {
                rotateNet += 1;

                if (rotateNet > maxRotation) rotate = false;

            }

            if (!rotate) //when not rotating, it rotates back
            {
                rotateNet -= 1;

                if (rotateNet <= 10) rotateNet = 10;
            }

            //updating rotations
            gameObject.transform.eulerAngles = new Vector3(
            rotateNet,
            gameObject.transform.eulerAngles.y,
            gameObject.transform.eulerAngles.z
            );
        }

    }
}
