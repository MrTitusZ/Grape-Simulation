using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] tokek;
    [SerializeField] int tokekSzama = 0;
    [SerializeField] int sorokSzama = 1;
    [SerializeField] float sorokKozottiTabolsag = 2f;
    [SerializeField] float tokekKozottiTavolsag = 2f;
    [SerializeField] float tokekKozottRandomMinTavolsag = 0.2f;
    [SerializeField] float tokekKozottRandomMaxTavolsag = 0.5f;
    [SerializeField] float tokeRandomYRotationFokban = 30f;

    float zCord = 1;
    float randomTavolsag;
    int tokeRandomIndex;
    float tokeRandomRotation;

    void Start()
    {
        GenerateGrapeField();
    }

    private void GenerateGrapeField()
    {
        for (int j = 0; j < sorokSzama; j++)
        {
            for (int i = 0; i < tokekSzama; i++)
            {
                tokeRandomIndex = Random.Range(0, tokek.Length);
                tokeRandomRotation = Random.Range(-tokeRandomYRotationFokban, tokeRandomYRotationFokban);
                Instantiate(tokek[tokeRandomIndex], new Vector3(1 + j * sorokKozottiTabolsag, 0, zCord), Quaternion.Euler(0, tokeRandomRotation, 0));
                randomTavolsag = Random.Range(tokekKozottRandomMinTavolsag, tokekKozottRandomMaxTavolsag);
                zCord += tokekKozottiTavolsag + randomTavolsag;
                Debug.Log(tokeRandomYRotationFokban);
            }
            zCord = 1;
        }
    }
}
