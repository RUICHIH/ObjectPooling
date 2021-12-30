using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPoolScript : MonoBehaviour
{

    List<ObjectPooler> prefab;

    [SerializeField]
    int number = 10;
    // Start is called before the first frame update
    void Start()
    {
        Init(number);
    }

    public void Init(int number)
    {
        this.number = number;
        prefab = new List<ObjectPooler>();
        for (int i = 0; i < number; i++)
        {
            var rt = Resources.Load("Cube");
            var rtGO = rt as GameObject;
            rtGO.SetActive(false);
            var go3 = GameObject.Instantiate(rtGO);
            prefab.Add(new ObjectPooler { gameObject = go3, isUsing = false });
        }
    }

    public void Load()
    {
        var OPLength = prefab.Where(o => o.isUsing).Count();
        if(OPLength == number)
        {
            return;
        }
        var target = prefab.First(o => o.isUsing == false);
        if (target == null) return;
        target.isUsing = true;
        target.gameObject.SetActive(true);
    }

    public void Unload(GameObject remove)
    {
        var OPLength = prefab.Where(o => o.isUsing == false).Count();
        if (OPLength == number)
        {
            return;
        }
        var target = prefab.First(o => o.isUsing == remove);
        if (target == null) return;
        target.isUsing = false;
        target.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Load();
        }
    }

    public class ObjectPooler
    {
        public GameObject gameObject;

        public bool isUsing;
    }

}
