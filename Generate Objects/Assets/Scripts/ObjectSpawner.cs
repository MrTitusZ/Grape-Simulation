using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Tõke Beállítások")]
    [SerializeField] GameObject[] tokek;
    [SerializeField] int tokekSzama = 0;
    [SerializeField] int sorokSzama = 1;

    [Header("")]
    [SerializeField] float sorokKozottiFixTavolsag = 2f;
    [SerializeField] float sorokKozottiRandomTavolsag = 0.5f;
    [SerializeField] float tokekKozottiTavolsag = 2f;
    [SerializeField] float tokekKozottiRandomTavolsag = 0.5f;
    [SerializeField] float tokeRandomYRotationFokban = 30f;

    float zCord = 1;
    float tokeRandomTavolsag;
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
                sorokKozottiRandomTavolsag = Random.Range(0, sorokKozottiRandomTavolsag);
                Vector3 grapePosition = new Vector3(1 + j * sorokKozottiFixTavolsag, 0f, zCord);
                Instantiate(tokek[tokeRandomIndex], grapePosition, Quaternion.Euler(0f, tokeRandomRotation, 0f));
                tokeRandomTavolsag = Random.Range(0, tokekKozottiRandomTavolsag);
                zCord += tokekKozottiTavolsag + tokeRandomTavolsag;
            }
            zCord = 1;
        }
    }
}
