using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{

    public void Main()
    {
    }

    public void Start()
    {
        Object.Destroy(this.gameObject, (float) 7);
    }

    public void Update()
    {
    }
}

