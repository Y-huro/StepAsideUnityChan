using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    // carPrefab������
    public GameObject carPrefab;
    // coinPrefab������
    public GameObject coinPrefab;
    // cornPrefab������
    public GameObject conePrefab;

    // �X�^�[�g�n�_
    private int startPos = 80;
    // �S�[���n�_
    private int goalPos = 360;
    // �A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    // ���W�ۑ�i���j�e�B�����̈ʒu�ɉ����ăA�C�e�������j�p�錾
    
    // ���̍쐬�\��ʒu
    private int generatePos;
    // �쐬�\��ʒu�z���̔���
    private bool lineOver = false;
    // Unity����񂩂猩���쐬�J�n����
    private int generateDifference = 40;
    // Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;


    void Start()
    {
        // ���̋������ƂɃA�C�e���𐶐�
        //for (int i = startPos; i < goalPos; i += 15)

        // �I�u�W�F�N�g�쐬�J�n�ʒu�����j�e�B�����̎�����ɂ���ꍇ
        if (startPos < generateDifference)
        {
            for (generatePos = startPos; generatePos < generateDifference; generatePos += 15)
            {
                itemGenerate(generatePos);

                /*
                // �ǂ̃A�C�e�����o���̂��������_���ɐݒ�
                int num = Random.Range(1, 11);
                if(num <= 2)
                {
                    // �R�[����x�������Ɉ꒼���ɐ���
                    for(float j = -1;j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                    }
                }
                else
                {
                    // ���[�����ƂɃA�C�e���𐶐�
                    for(int j = -1;j <= 1; j++)
                    {
                        // �A�C�e���̎�ނ����߂�
                        int item = Random.Range(1, 11);
                        // �A�C�e����u��z���W�̃I�t�Z�b�g�������_���ɐݒ�
                        int offsetZ = Random.Range(-5, 6);
                        // 60%�R�C���z�u�F30%�Ԕz�u�F10%�����Ȃ�
                        if(1 <= item && item <= 6)
                        {
                            // �R�C���𐶐�
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                        }
                        else if(7 <= item && item <= 9)
                        {
                            // �Ԃ𐶐�
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                        }
                    }
                }*/

            }
        }
        else
        {
            generatePos = startPos;
        }

        // Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!lineOver)
        {
            if (generatePos < goalPos && generatePos <= unitychan.transform.position.z + generateDifference)
            {
                lineOver = true;
            }
        }
        if (lineOver)
        {
            itemGenerate(generatePos);
            generatePos += 15;
            lineOver = false;
        }

    }

    private void itemGenerate(int generatePlace)
    {
        int num = Random.Range(1, 11);
        if (num <= 2)
        {
            // �R�[����x�������Ɉ꒼���ɐ���
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, generatePlace);
            }
        }
        else
        {
            // ���[�����ƂɃA�C�e���𐶐�
            for (int j = -1; j <= 1; j++)
            {
                // �A�C�e���̎�ނ����߂�
                int item = Random.Range(1, 11);
                // �A�C�e����u��z���W�̃I�t�Z�b�g�������_���ɐݒ�
                int offsetZ = Random.Range(-5, 6);
                // 60%�R�C���z�u�F30%�Ԕz�u�F10%�����Ȃ�
                if (1 <= item && item <= 6)
                {
                    // �R�C���𐶐�
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, generatePlace + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    // �Ԃ𐶐�
                    GameObject car = Instantiate(carPrefab);
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, generatePlace + offsetZ);
                }
            }
        }
    }
}
