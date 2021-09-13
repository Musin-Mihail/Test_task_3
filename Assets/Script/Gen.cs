using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen : MonoBehaviour
{
    public List<GameObject> _gameObjects;
    public List<GameObject> _gameObjects2; 
    public List<GameObject> _gameObjects3; 
    public List<Vector3> Vertox;
    public List<int> Tringle;
    public List<Vector3> Normals;
    [Range(0,50)]public int Count;
    int _z;
    void Start()
    {
        Mesh _mesh = new Mesh();
        _mesh.name = "Test Mesh";
        _z = 0;
        for (int i = 0; i < Count; i++)
        { 
            for (int t = 0; t < _gameObjects.Count; t++)
            {
                Vector3 newVector3 = _gameObjects[t].transform.position;
                newVector3.z = _z;
                Vertox.Add(newVector3);
                Normals.Add(-Vector3.down);
            }
            _z ++;
        }
        for (int t = 0; t < _gameObjects.Count-1; t++)
            {
                for (int i = 0; i < Count-1; i++)
                {
                    int Index1 = i * _gameObjects.Count + t;
                    int Index2 = Index1 + _gameObjects.Count;
                    int Index3 = Index2 + 1;
                    int Index4 = Index1;
                    int Index5 = Index3;
                    int Index6 = Index1 + 1;
                    Tringle.Add(Index1);
                    Tringle.Add(Index2);
                    Tringle.Add(Index3);
                    Tringle.Add(Index4);
                    Tringle.Add(Index5);
                    Tringle.Add(Index6);
                } 
            }
        _mesh.SetVertices(Vertox);
        _mesh.SetTriangles(Tringle, 0);
        _mesh.SetNormals(Normals);
        GetComponent<MeshFilter>().sharedMesh = _mesh;
        GetComponent<MeshCollider>().sharedMesh = _mesh;
    }
}
