using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pendingDoom : MonoBehaviour
{
    public Button btn;
    public float speedFloat = 0.5f;
    private Vector3 speed;
    // Start is called before the first frame update
    void Start(){
        speed = new Vector3(speedFloat,speedFloat,speedFloat);
    }
    // Update is called once per frame
    void Update()
    {
        btn.transform.localScale = btn.transform.localScale + speed * Time.deltaTime;
    }
}
