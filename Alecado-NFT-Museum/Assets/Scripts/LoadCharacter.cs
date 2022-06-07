using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public Text chrName;
    public Text chrRole;

    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        clone.transform.parent = spawnPoint;
        chrName.text = PlayerPrefs.GetString("characterName");
        chrRole.text = PlayerPrefs.GetString("playerRole");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
