using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;

public class LoadCharacter : Photon.PunBehaviour
{
    public GameObject[] characterPrefabs;
    public GameObject roboPrefab;
    public Transform spawnPoint;
    public Transform spawnPointforRobo;
    public Text chrName;
    public Text chrRole;
    GameObject t1;
    GameObject t2;

    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        //GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        GameObject clone = PhotonNetwork.Instantiate(prefab.name, spawnPoint.position, Quaternion.identity, 0);


        GameObject clone2 = PhotonNetwork.Instantiate(roboPrefab.name, spawnPointforRobo.position, Quaternion.identity, 0);

        clone.transform.parent = spawnPoint;

        chrName.text = PlayerPrefs.GetString("characterName");
        chrRole.text = PlayerPrefs.GetString("playerRole");
        initialiseRobo(clone, clone2);
        clone.SetActive(false);
    }

    private void initialiseRobo(GameObject clone, GameObject clone2)
    {
        RoboFollow rf = clone2.GetComponent<RoboFollow>();
        t1 = clone.GetComponent<ACtrl>().t1.gameObject;
        t2 = clone.GetComponent<ACtrl>().t2.gameObject;
        rf.target1 = t1;
        rf.target2 = t2;

        HeadFollow hf = clone2.GetComponentInChildren<HeadFollow>();
        hf.player = clone;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
