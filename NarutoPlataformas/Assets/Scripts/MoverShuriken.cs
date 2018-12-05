using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverShuriken : MonoBehaviour {
    private Transform miTransform;
    public int velocidad;
    public Vector3 _velocidad;
	// Use this for initialization
	void Start () {
        miTransform = this.transform;
        
	}
    private void OnEnable() {
        Invoke("reiniciar", 5);
    }

    // Update is called once per frame
    void Update () {
        miTransform.Translate(_velocidad * velocidad * Time.deltaTime);
	}
    public void reiniciar() {
        UnityEditor.PrefabUtility.ResetToPrefabState(this.gameObject);
        GameObject.Find("PoolObjectManager").GetComponent<PoolObject>().AnadirShurikens(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
