using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=FVXGgPCxvpY
// https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
// quad click player to follow, unsure why 4 clicks.
public class PickUpItem : MonoBehaviour
{
    public int score = 0;
    public GameObject winMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Send a ray cast out from player
        RaycastHit hit;
        Coin go;

        // "out hit" tells hit what we hit
        if (Physics.Raycast(transform.position, transform.forward, out hit, 4f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");

            go = hit.transform.GetComponent<Coin>();

            if (go == null)
            {
                Debug.Log("Not a coin");
            }
            else
            {

                if ((go.isCoin == true) &&
                    (Input.GetKey("e")))
                {
                    Debug.Log("Found coin");

                    score++;
                    Destroy(hit.transform.gameObject);
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.white);
            Debug.Log("Did not Hit");
        }

        if (score == 3)
        {
            // game over
            GetComponent<PlayerMove>().enabled = false;

            winMessage.SetActive(true);
        }
    }
}
