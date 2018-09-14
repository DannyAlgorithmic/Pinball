using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPools : ScriptableObject {

    private static Dictionary<int, Queue<GameObject>> poolDict = new Dictionary<int, Queue<GameObject>>();

    public static void CreatePool(GameObject _prefab, int _count)
    {
        int poolKey = _prefab.GetInstanceID();

        if (!poolDict.ContainsKey(poolKey))
        {
            Queue<GameObject> pool = new Queue<GameObject>();
            for (int i = 0; i < _count; i++)
            {
                GameObject obj = Instantiate(_prefab, null);
                obj.SetActive(false);
                pool.Enqueue(obj);
            }
            poolDict.Add(poolKey, pool);
        }
    }

    public GameObject ReuseObject(GameObject _prefab, Vector2 _pos, Quaternion _rot, Transform _parent)
    {
        int poolKey = _prefab.GetInstanceID();
        GameObject output = null;

        if (poolDict.ContainsKey(poolKey))
        {
            output = poolDict[poolKey].Dequeue();
            Transform trans = output.transform;
            trans.position = _pos;
            trans.rotation = _rot;
            trans.parent = _parent;

            output.SetActive(false);
            poolDict[poolKey].Enqueue(output);
        }

        return output;
    }

}
