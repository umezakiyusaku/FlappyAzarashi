using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public GameObject root;
    public Transform bottomBlock;
    // Start is called before the first frame update
    void Start()
    {
        ChangeHeight();
    }
    void ChangeHeight() {
        float height = Random.Range(minHeight, maxHeight);
        root.transform.localPosition = new Vector3(0f, height, 0f);
        float offset = Random.Range(-2f, 2f);
        bottomBlock.localPosition=new Vector3(0f, offset, 0f);
    }

    void OnScrollEnd() {
        ChangeHeight();
    }
}
