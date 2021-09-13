using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Line : MonoBehaviour
{
    public List<Transform> _ListTransform;
    static public float t;
    // int Win = 0;
    // public GameObject WinG;
    void Start()
    {
        t = 0;
        StartCoroutine(Gen());
        transform.position = Bezier.GetPoint2(_ListTransform, t);
        Vector3 _new = Bezier.GetPoint2(_ListTransform, 0.0002f);
        transform.LookAt(_new);
    }
    private void OnDrawGizmos() 
    {
        int sigmentNumber = 40;
        Vector3 preveousPoint = _ListTransform[0].position;
        for (int i = 0; i < sigmentNumber + 1; i++)
        {
            float paremeter = (float)i / sigmentNumber;
            Vector3 point = Bezier.GetPoint2(_ListTransform, paremeter);
            Gizmos.DrawLine(preveousPoint, point);
            preveousPoint = point;
        }
    }
    IEnumerator Gen()
    {
        transform.position = _ListTransform[0].position;
        yield return new WaitForSeconds(0.01f);
        while(t<1)
        {
            transform.position = Bezier.GetPoint2(_ListTransform, t);
            // if(t > 0.985f && Win == 0)
            // {
            //     Win = 1;
            //     var win2 = Instantiate(WinG,transform.position, Quaternion.identity);
            //     win2.transform.LookAt(Bezier.GetPoint2(_ListTransform, t+0.001f));
            // }
            t+=0.001f;
            Vector3 _new = Bezier.GetPoint2(_ListTransform, t);
            transform.LookAt(_new);
            yield return new WaitForSeconds(0.00001f);
        }
    }
}