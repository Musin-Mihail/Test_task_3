using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Level1 : MonoBehaviour
{
    public List<GameObject> _gameObjects4; //Bridge
    public List<Vector3> Vertox;
    public List<int> Tringle;
    public List<Vector3> Normals;
    Vector3 _oldVector3;
    public GameObject _prefab;
    void Start()
    {
        _oldVector3 = transform.position;
        StartCoroutine(MeshGeneration(_gameObjects4, 0.999f));
    }
    IEnumerator MeshGeneration(List<GameObject> _gameObject, float _distant)
    {
        int count = 0;
        foreach (var item in _gameObject)
        {
            Vertox.Add(item.transform.position);
            Normals.Add(-Vector3.down);
        }
        while (Line.t < _distant)
        {
            if(Vector3.Distance(transform.position, _oldVector3) > 0.5f)
            {
                count++;
                _oldVector3 = transform.position;
                foreach (var item in _gameObject)
                {
                    Vertox.Add(item.transform.position);
                    Normals.Add(-Vector3.down);
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
        count++;
        foreach (var item in _gameObject)
        {
            Vertox.Add(item.transform.position);
            Normals.Add(-Vector3.down);
        }
        for (int t = 0; t < _gameObject.Count-1; t++)
        {
            for (int i = 0; i < count; i++)
            {
                int Index1 = i * _gameObject.Count + t;
                int Index2 = Index1 + _gameObject.Count;
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
        Mesh _mesh = new Mesh();
        _mesh.name = "Road";
        _mesh.SetVertices(Vertox);
        _mesh.SetTriangles(Tringle, 0);
        _mesh.SetNormals(Normals);
        _mesh.RecalculateNormals();
        Vertox.Clear();
        Tringle.Clear();
        Normals.Clear();
        var mesh = Instantiate(_prefab, Vector3.zero, Quaternion.identity);
        mesh.GetComponent<MeshFilter>().sharedMesh = _mesh; 
        mesh.GetComponent<MeshCollider>().sharedMesh = _mesh; 
        // _status = 1;
        AssetDatabase.CreateAsset(mesh.GetComponent<MeshFilter>().mesh, "Assets/SavedMesh.asset");
    }
}