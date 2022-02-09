using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

public class Camara : MonoBehaviour
{
    private GameObject land;
    private GameObject land2;
    private GameObject land3;
    private GameObject forest;
    private GameObject forest2;
    private GameObject forest3;
    private GameObject rock;
    private GameObject rock2;
    private GameObject rock3;
    private GameObject rock4;
    private GameObject mainUI;
    private GameObject buttonUI;
    private GameObject explosion;
    private GameObject Man;
    private GameObject ManPick;
    private GameObject Dino;
    private GameObject Music;
    private GameObject Fader;
    private GameObject number1UI;
    private GameObject number2UI;
    private GameObject operationUI;
    private GameObject equalUI;
    private GameObject result1UI;
    private GameObject result2UI;
    private GameObject correctUI;
    private GameObject score1UI;
    private GameObject score2UI;
    private GameObject score3UI;
    private float pickCount;
    private float manMoveValue = 0.5f;
    private bool Rst;
    private float RstTime;
    private float Xcam;
    private float Ycam;
    private float angle;
    private float RandomNum;
    private float RandomNum2;
    private float RandomOpe;
    private bool randomRst;
    private int num1;
    private int num2;
    private int ansRst;
    private int result;
    private bool resultRst;
    private bool resultRst2;
    private int trueResult;
    private float moveDificulty = 0.01f;
    private int loQueDurasteALV;
    private bool ansRst2 = false;
    private bool ansRst3 = false;
    private bool mainSongRst = false;
    private float colorNum = 1;
    private float scoreMoveY = -9.93f;
    private bool minerDieRst;
    private bool boomRst;

    void Start()
    {
        Man = GameObject.Find("ScaryMan");
        Dino = GameObject.Find("T-Rex");
        Man.GetComponent<Animator>().SetBool("miner", true);
        Dino.GetComponent<Animator>().SetBool("charizard", true);
        if (Dino.GetComponent<Animator>().GetBool("swalot"))
        {
            Dino.transform.position = new Vector3(-7.67f, -4.66f, -2);
            Dino.transform.localScale = new Vector2(3, 3);
            Dino.GetComponent<SpriteRenderer>().flipX = false;
        }   
        else if (Dino.GetComponent<Animator>().GetBool("rex"))
        {
            Dino.transform.position = new Vector3(-10.4f, -5.05f, -2);
            Dino.transform.localScale = new Vector2(8, 8);
            Dino.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Dino.GetComponent<Animator>().GetBool("charizard"))
        {
            Dino.transform.position = new Vector3(-8.37f, -4.42f, -2);
            Dino.transform.localScale = new Vector2(8, 8);
            Dino.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void ManMove(float X, string direction)
    {
        if (direction == "+")
        {
            manMoveValue += X;
        }
        else if (direction == "-")
        {
            manMoveValue -= X;
        }       
        Man.GetComponent<Transform>().position = new Vector3(manMoveValue, Man.GetComponent<Transform>().position.y, Man.GetComponent<Transform>().position.z);
    }

    void AudioPlay(GameObject theObject, GameObject variable, string animation)
    {
        if (variable.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(animation) == true && mainSongRst == false)
        {
            theObject.GetComponent<AudioSource>().Play();
            mainSongRst = true;
        }
        else if (variable.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(animation) == false && mainSongRst == true)
        {
            mainSongRst = false;
        }
    }

    void AudioPlay2(GameObject theObject, GameObject variable, string animation)
    {
        if (variable.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(animation) == true && ansRst2 == false)
        {
            theObject.GetComponent<AudioSource>().Play();
            loQueDurasteALV += 1;
            ansRst2 = true;
        }
    }

    void AudioPlay3(GameObject theObject, GameObject variable, string animation)
    {
        if (variable.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(animation) == true && ansRst3 == false)
        {
            theObject.GetComponent<AudioSource>().Play();
            ansRst3 = true;
        }
    }

    void AllNumFalse()
    {
        number1UI.GetComponent<Animator>().SetBool("0", false);
        number1UI.GetComponent<Animator>().SetBool("1", false);
        number1UI.GetComponent<Animator>().SetBool("2", false);
        number1UI.GetComponent<Animator>().SetBool("3", false);
        number1UI.GetComponent<Animator>().SetBool("4", false);
        number1UI.GetComponent<Animator>().SetBool("5", false);
        number1UI.GetComponent<Animator>().SetBool("6", false);
        number1UI.GetComponent<Animator>().SetBool("7", false);
        number1UI.GetComponent<Animator>().SetBool("8", false);
        number1UI.GetComponent<Animator>().SetBool("9", false);

        number2UI.GetComponent<Animator>().SetBool("0", false);
        number2UI.GetComponent<Animator>().SetBool("1", false);
        number2UI.GetComponent<Animator>().SetBool("2", false);
        number2UI.GetComponent<Animator>().SetBool("3", false);
        number2UI.GetComponent<Animator>().SetBool("4", false);
        number2UI.GetComponent<Animator>().SetBool("5", false);
        number2UI.GetComponent<Animator>().SetBool("6", false);
        number2UI.GetComponent<Animator>().SetBool("7", false);
        number2UI.GetComponent<Animator>().SetBool("8", false);
        number2UI.GetComponent<Animator>().SetBool("9", false);

        result1UI.GetComponent<Animator>().SetBool("0", false);
        result1UI.GetComponent<Animator>().SetBool("1", false);
        result1UI.GetComponent<Animator>().SetBool("2", false);
        result1UI.GetComponent<Animator>().SetBool("3", false);
        result1UI.GetComponent<Animator>().SetBool("4", false);
        result1UI.GetComponent<Animator>().SetBool("5", false);
        result1UI.GetComponent<Animator>().SetBool("6", false);
        result1UI.GetComponent<Animator>().SetBool("7", false);
        result1UI.GetComponent<Animator>().SetBool("8", false);
        result1UI.GetComponent<Animator>().SetBool("9", false);

        result2UI.GetComponent<Animator>().SetBool("0", false);
        result2UI.GetComponent<Animator>().SetBool("1", false);
        result2UI.GetComponent<Animator>().SetBool("2", false);
        result2UI.GetComponent<Animator>().SetBool("3", false);
        result2UI.GetComponent<Animator>().SetBool("4", false);
        result2UI.GetComponent<Animator>().SetBool("5", false);
        result2UI.GetComponent<Animator>().SetBool("6", false);
        result2UI.GetComponent<Animator>().SetBool("7", false);
        result2UI.GetComponent<Animator>().SetBool("8", false);
        result2UI.GetComponent<Animator>().SetBool("9", false);

        operationUI.GetComponent<Animator>().SetBool("-", false);
        operationUI.GetComponent<Animator>().SetBool("+", false);
    }

    int RandomVal(GameObject object1, GameObject object2)
    {
        if (randomRst == false)
        {
            RandomNum = UnityEngine.Random.value;
            RandomNum2 = UnityEngine.Random.value;
            RandomOpe = UnityEngine.Random.value;
            equalUI.GetComponent<Animator>().SetBool("equals", true);
            if (RandomNum >= 0 && RandomNum <= 0.1f)
            {
                object1.GetComponent<Animator>().SetBool("0", true);
                num1 = 0;
            }
            else if (RandomNum > 0.1f && RandomNum <= 0.2f)
            {
                object1.GetComponent<Animator>().SetBool("1", true);
                num1 = 1;
            }
            else if (RandomNum > 0.2f && RandomNum <= 0.3f)
            {
                object1.GetComponent<Animator>().SetBool("2", true);
                num1 = 2;
            }
            else if (RandomNum > 0.3f && RandomNum <= 0.4f)
            {
                object1.GetComponent<Animator>().SetBool("3", true);
                num1 = 3;
            }
            else if (RandomNum > 0.4f && RandomNum <= 0.5f)
            {
                object1.GetComponent<Animator>().SetBool("4", true);
                num1 = 4;
            }
            else if (RandomNum > 0.5f && RandomNum <= 0.6f)
            {
                object1.GetComponent<Animator>().SetBool("5", true);
                num1 = 5;
            }
            else if (RandomNum > 0.6f && RandomNum <= 0.7f)
            {
                object1.GetComponent<Animator>().SetBool("6", true);
                num1 = 6;
            }
            else if (RandomNum > 0.7f && RandomNum <= 0.8f)
            {
                object1.GetComponent<Animator>().SetBool("7", true);
                num1 = 7;
            }
            else if (RandomNum > 0.8f && RandomNum <= 0.9f)
            {
                object1.GetComponent<Animator>().SetBool("8", true);
                num1 = 8;
            }
            else if (RandomNum > 0.9f && RandomNum <= 1f)
            {
                object1.GetComponent<Animator>().SetBool("9", true);
                num1 = 9;
            }
            // numero aleatorio 2 //
            if (RandomNum2 >= 0 && RandomNum2 <= 0.1f)
            {
                object2.GetComponent<Animator>().SetBool("0", true);
                num2 = 0;
            }
            else if (RandomNum2 > 0.1f && RandomNum2 <= 0.2f)
            {
                object2.GetComponent<Animator>().SetBool("1", true);
                num2 = 1;
            }
            else if (RandomNum2 > 0.2f && RandomNum2 <= 0.3f)
            {
                object2.GetComponent<Animator>().SetBool("2", true);
                num2 = 2;
            }
            else if (RandomNum2 > 0.3f && RandomNum2 <= 0.4f)
            {
                object2.GetComponent<Animator>().SetBool("3", true);
                num2 = 3;
            }
            else if (RandomNum2 > 0.4f && RandomNum2 <= 0.5f)
            {
                object2.GetComponent<Animator>().SetBool("4", true);
                num2 = 4;
            }
            else if (RandomNum2 > 0.5f && RandomNum2 <= 0.6f)
            {
                object2.GetComponent<Animator>().SetBool("5", true);
                num2 = 5;
            }
            else if (RandomNum2 > 0.6f && RandomNum2 <= 0.7f)
            {
                object2.GetComponent<Animator>().SetBool("6", true);
                num2 = 6;
            }
            else if (RandomNum2 > 0.7f && RandomNum2 <= 0.8f)
            {
                object2.GetComponent<Animator>().SetBool("7", true);
                num2 = 7;
            }
            else if (RandomNum2 > 0.8f && RandomNum2 <= 0.9f)
            {
                object2.GetComponent<Animator>().SetBool("8", true);
                num2 = 8;
            }
            else if (RandomNum2 > 0.9f && RandomNum2 <= 1f)
            {
                object2.GetComponent<Animator>().SetBool("9", true);
                num2 = 9;
            }
            randomRst = true;
        }
                                           // operacion aleatoria //

        if (num1 > num2)
        {
            if (RandomOpe < 0.5f)
            {
                operationUI.GetComponent<Animator>().SetBool("-", true);
                trueResult = num1 - num2;
                return num1 - num2;
            }
            else
            {
                operationUI.GetComponent<Animator>().SetBool("+", true);
                trueResult = num1 + num2;
                return num1 + num2;
            }
    }
        else
        {
            operationUI.GetComponent<Animator>().SetBool("+", true);
            trueResult = num1 + num2;
            return num1 + num2;
        }
    }

    int Result(GameObject object1, GameObject object2)
    {
        if (resultRst == false)
        {
            if (object1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("0"))
            {
                result += 0;
                resultRst = true;
            }
            else if (object1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("1"))
            {
                result += 1;
                resultRst = true;
            }
            else if (object1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("2"))
            {
                result += 2;
                resultRst = true;
            }
            else if (object1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("3"))
            {
                result += 3;
                resultRst = true;
            }
            else if (object1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("4"))
            {
                result += 4;
                resultRst = true;
            }
            else if (object1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("5"))
            {
                result += 5;
                resultRst = true;
            }
            else if (object1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("6"))
            {
                result += 6;
                resultRst = true;
            }
            else if (object1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("7"))
            {
                result += 7;
                resultRst = true;
            }
            else if (object1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("8"))
            {
                result += 8;
                resultRst = true;
            }
            else if (object1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("9"))
            {
                result += 9;
                resultRst = true;
            }
        }
        // objeto 2 //
        if (resultRst2 == false)
        {
            if (!object1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("blank"))
            {
                if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("0"))
                {
                    result += 0;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("1"))
                {
                    result += 10;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("2"))
                {
                    result += 20;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("3"))
                {
                    result += 30;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("4"))
                {
                    result += 40;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("5"))
                {
                    result += 50;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("6"))
                {
                    result += 60;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("7"))
                {
                    result += 70;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("8"))
                {
                    result += 80;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("9"))
                {
                    result += 90;
                    resultRst2 = true;
                }
            }
            else if (object1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("blank"))
            {
                if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("0"))
                {
                    result += 0;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("1"))
                {
                    result += 1;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("2"))
                {
                    result += 2;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("3"))
                {
                    result += 3;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("4"))
                {
                    result += 4;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("5"))
                {
                    result += 5;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("6"))
                {
                    result += 6;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("7"))
                {
                    result += 7;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("8"))
                {
                    result += 8;
                    resultRst2 = true;
                }
                else if (object2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("9"))
                {
                    result += 9;
                    resultRst2 = true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            return result;
        }
        else
        {
            return 0;
        }
    }

    void Answer()
    {
        if (ansRst < 0)
        {
            ansRst = 0;
        }
        if (ansRst == 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                result1UI.GetComponent<Animator>().SetBool("0", true);
                ansRst = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                result1UI.GetComponent<Animator>().SetBool("1", true);
                ansRst = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                result1UI.GetComponent<Animator>().SetBool("2", true);
                ansRst = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                result1UI.GetComponent<Animator>().SetBool("3", true);
                ansRst = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                result1UI.GetComponent<Animator>().SetBool("4", true);
                ansRst = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                result1UI.GetComponent<Animator>().SetBool("5", true);
                ansRst = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                result1UI.GetComponent<Animator>().SetBool("6", true);
                ansRst = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                result1UI.GetComponent<Animator>().SetBool("7", true);
                ansRst = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                result1UI.GetComponent<Animator>().SetBool("8", true);
                ansRst = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                result1UI.GetComponent<Animator>().SetBool("9", true);
                ansRst = 1;
            }
        }
        else if (ansRst == 1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                result2UI.GetComponent<Animator>().SetBool("0", true);
                ansRst = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                result2UI.GetComponent<Animator>().SetBool("1", true);
                ansRst = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                result2UI.GetComponent<Animator>().SetBool("2", true);
                ansRst = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                result2UI.GetComponent<Animator>().SetBool("3", true);
                ansRst = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                result2UI.GetComponent<Animator>().SetBool("4", true);
                ansRst = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                result2UI.GetComponent<Animator>().SetBool("5", true);
                ansRst = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                result2UI.GetComponent<Animator>().SetBool("6", true);
                ansRst = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                result2UI.GetComponent<Animator>().SetBool("7", true);
                ansRst = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                result2UI.GetComponent<Animator>().SetBool("8", true);
                ansRst = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                result2UI.GetComponent<Animator>().SetBool("9", true);
                ansRst = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                AllNumFalse();
                if (trueResult == Result(result2UI, result1UI))
                {
                    correctUI.GetComponent<Animator>().SetBool("true", true);
                }
                else
                {
                    correctUI.GetComponent<Animator>().SetBool("false", true);
                }
                randomRst = false;
                result = 0;
                resultRst = false;
                resultRst2 = false;
                ansRst = 0;
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                result = 0;
                resultRst = false;
                resultRst2 = false;
                AllNumFalse();
                ansRst -= 1;
            }
        }
        else if (ansRst == 2)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                AllNumFalse();
                if (trueResult == Result(result2UI, result1UI))
                {
                    correctUI.GetComponent<Animator>().SetBool("true", true);
                }
                else
                {
                    correctUI.GetComponent<Animator>().SetBool("false", true);
                }
                randomRst = false;
                result = 0;
                resultRst = false;
                resultRst2 = false;
                ansRst = 0;
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                result = 0;
                resultRst = false;
                resultRst2 = false;
                AllNumFalse();
                ansRst -= 2;
            }
        }
    }

    void Update()
    {
        land = GameObject.Find("land");
        land2 = GameObject.Find("land2");
        land3 = GameObject.Find("land3");
        forest = GameObject.Find("ForestBackground");
        forest2 = GameObject.Find("ForestBackground2");
        forest3 = GameObject.Find("ForestBackground3");
        rock = GameObject.Find("rocks1");
        rock2 = GameObject.Find("rocks2");
        rock3 = GameObject.Find("rocks3");
        rock4 = GameObject.Find("rocks4");
        mainUI = GameObject.Find("main ui");
        buttonUI = GameObject.Find("button ui");
        explosion = GameObject.Find("explosion");
        Man = GameObject.Find("ScaryMan");
        ManPick = GameObject.Find("pick");
        Dino = GameObject.Find("T-Rex");
        Music = GameObject.Find("Music");
        Fader = GameObject.Find("Image");
        number1UI = GameObject.Find("number1");
        number2UI = GameObject.Find("number2");
        operationUI = GameObject.Find("operation");
        equalUI = GameObject.Find("equals");
        result1UI = GameObject.Find("result1");
        result2UI = GameObject.Find("result2");
        correctUI = GameObject.Find("correct");
        score1UI = GameObject.Find("unityScore");
        score2UI = GameObject.Find("decimalScore");
        score3UI = GameObject.Find("scoreUI");

        if (Man.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("walk") == true)
        {
            AudioPlay(this.gameObject, Man, "walk");
            if (correctUI.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("blanko"))
            {
                Answer();
                RandomVal(number1UI, number2UI);
            }
            if (correctUI.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("correct"))
            {
                AudioPlay2(result1UI, correctUI, "correct");
                if (Man.transform.position.x < 4.5f)
                {
                    ManMove(0.025f, "+");
                }
                else
                {
                    ManMove(0f, "+");
                }
                correctUI.GetComponent<Animator>().SetBool("true", false);
            }
            else if (correctUI.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("false"))
            {
                AudioPlay3(result2UI, correctUI, "false");
                if (Man.transform.position.x > -2.5f)
                {
                    ManMove(moveDificulty, "-");
                }
                else
                {
                    ManMove(0f, "-");
                }
                correctUI.GetComponent<Animator>().SetBool("false", false);
            }
            else
            {
                ManMove(moveDificulty, "-");
            }
            if (Man.transform.position.x <= -2.5f)
            {
                Man.GetComponent<Animator>().SetBool("die", true);
                Dino.GetComponent<Animator>().SetBool("bite", true);
                Dino.GetComponent<Animator>().SetBool("run", false);
                Man.GetComponent<Animator>().SetBool("run", false);
            }
            land.GetComponent<Animator>().StopPlayback();
            land2.GetComponent<Animator>().StopPlayback();
            land3.GetComponent<Animator>().StopPlayback();
            forest.GetComponent<Animator>().StopPlayback();
            forest2.GetComponent<Animator>().StopPlayback();
            forest3.GetComponent<Animator>().StopPlayback();
        }
        else
        {
            if (mainUI.GetComponent<SpriteRenderer>().color.a == 0 && pickCount >= 1.5f && Man.GetComponent<Transform>().position.x < 4.5f && !Man.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die"))
            {
                explosion.GetComponent<Animator>().SetBool("boom", true);
                rock.GetComponent<Animator>().SetBool("boom", true);
                rock2.GetComponent<Animator>().SetBool("boom", true);
                rock3.GetComponent<Animator>().SetBool("boom", true);
                rock4.GetComponent<Animator>().SetBool("boom", true);
                Man.GetComponent<Animator>().SetBool("run", true);
                Dino.GetComponent<Animator>().SetBool("run", true);
                ManMove(0.028f, "+");
            }
            land.GetComponent<Animator>().StartPlayback();
            land2.GetComponent<Animator>().StartPlayback();
            land3.GetComponent<Animator>().StartPlayback();
            forest.GetComponent<Animator>().StartPlayback();
            forest2.GetComponent<Animator>().StartPlayback();
            forest3.GetComponent<Animator>().StartPlayback();
        }     
        if (Man.GetComponent<SpriteRenderer>().sprite.name == "mining1")
        {
            ManPick.GetComponent<Animator>().SetBool("pick", true);
        }
        else
        {
            ManPick.GetComponent<Animator>().SetBool("pick", false);
        }
        if (Man.GetComponent<SpriteRenderer>().sprite.name == "mineAlt")
        {
            ManPick.GetComponent<AudioSource>().Play();
        }
        if (buttonUI.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("button") == true && Input.anyKeyDown)
        {
            buttonUI.GetComponent<Animator>().SetBool("fade out", true);
            mainUI.GetComponent<Animator>().SetBool("fade", true);
        }
        if (mainUI.GetComponent<SpriteRenderer>().color.a == 0 && Man.GetComponent<SpriteRenderer>().sprite.name == "mining1")
        {
            pickCount += 0.2f;
        }
        if (Dino.GetComponent<SpriteRenderer>().sprite.name == "1" && (Dino.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("roar") || Dino.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("bite")))
        {
            Dino.GetComponent<AudioSource>().Play();
        }
        if (explosion.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("boom") && boomRst == false)
        {
            Music.GetComponent<AudioSource>().Stop();
            explosion.GetComponent<AudioSource>().Play();
            boomRst = true;
        }
        if (Dino.GetComponent<SpriteRenderer>().sprite.name == "T-Rex 2_6" || Dino.GetComponent<SpriteRenderer>().sprite.name == "swalot_31")
        {
            this.gameObject.GetComponent<AudioSource>().Stop();
            angle = 360 * UnityEngine.Random.value;
            Xcam = 0.25f * Mathf.Cos(angle);
            Ycam = 0.25f * Mathf.Sin(angle);
            this.transform.position = new Vector3(Xcam, Ycam, -10);
        }
        else
        {
            this.transform.position = new Vector3(0, 0, -10);
        }
        if ((Dino.GetComponent<SpriteRenderer>().sprite.name == "T-Rex 2_8" || Dino.GetComponent<SpriteRenderer>().sprite.name == "swalot_35") && minerDieRst == false)
        {
            Man.GetComponent<AudioSource>().Play();
            minerDieRst = true;
        }
        if (Dino.GetComponent<SpriteRenderer>().sprite.name == "T-RexAlt" || Dino.GetComponent<SpriteRenderer>().sprite.name == "swalot_50")
        {
            buttonUI.GetComponent<Animator>().SetBool("fade out", false);
            number1UI.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, colorNum);
            number2UI.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, colorNum);
            result1UI.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, colorNum);
            result2UI.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, colorNum);
            equalUI.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, colorNum);
            operationUI.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, colorNum);
            colorNum -= 0.02f;
            score1UI.GetComponent<Transform>().position = new Vector3(score1UI.GetComponent<Transform>().position.x, scoreMoveY, -8);
            score2UI.GetComponent<Transform>().position = new Vector3(score2UI.GetComponent<Transform>().position.x, scoreMoveY, -8);
            score3UI.GetComponent<Transform>().position = new Vector3(score3UI.GetComponent<Transform>().position.x, scoreMoveY + 2.5f, -8);
            if (scoreMoveY < 1)
            {
                scoreMoveY += 0.05f;
            }
            else
            {
                buttonUI.GetComponent<Transform>().position = new Vector3(0, -2, -3);
                buttonUI.GetComponent<Animator>().SetBool("fade in", true);
            }
            if (buttonUI.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("button") == true && Input.anyKeyDown)
            {
                buttonUI.GetComponent<Animator>().SetBool("fade out", true);
                Fader.GetComponent<Animator>().SetBool("fade", true);
            }
        }
        if (Dino.GetComponent<SpriteRenderer>().sprite.name == "7" || Dino.GetComponent<SpriteRenderer>().sprite.name == "swalot_26")
        {
            moveDificulty += 0.00003f;
        }
        if (Fader.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("fade OUT") && Fader.GetComponent<RectTransform>().pivot.x == 0.4f)
        {
            SceneManager.LoadScene(3);
        }
        if (correctUI.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("blanko") == true)
        {
            ansRst2 = false;
            ansRst3 = false;
        }
        if (Dino.GetComponent<SpriteRenderer>().sprite.name == "swalot_35")
        {
            Man.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
        }
        if (Dino.GetComponent<SpriteRenderer>().sprite.name == "charizard_5" && Dino.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("charBite"))
        {
            Man.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
        }
        if (loQueDurasteALV == 0 || loQueDurasteALV == 10 || loQueDurasteALV == 20 || loQueDurasteALV == 30
            || loQueDurasteALV == 40 || loQueDurasteALV == 50 || loQueDurasteALV == 60 || loQueDurasteALV == 70
            || loQueDurasteALV == 80 || loQueDurasteALV == 90)
        {
            score1UI.GetComponent<Animator>().SetBool("9", false);
            score1UI.GetComponent<Animator>().SetBool("0", true);
        }
        else if (loQueDurasteALV == 1 || loQueDurasteALV == 11 || loQueDurasteALV == 21 || loQueDurasteALV == 31
            || loQueDurasteALV == 41 || loQueDurasteALV == 51 || loQueDurasteALV == 61 || loQueDurasteALV == 71
            || loQueDurasteALV == 81 || loQueDurasteALV == 91)
        {
            score1UI.GetComponent<Animator>().SetBool("0", false);
            score1UI.GetComponent<Animator>().SetBool("1", true);
        }
        else if (loQueDurasteALV == 2 || loQueDurasteALV == 12 || loQueDurasteALV == 22 || loQueDurasteALV == 32
            || loQueDurasteALV == 42 || loQueDurasteALV == 52 || loQueDurasteALV == 62 || loQueDurasteALV == 72
            || loQueDurasteALV == 82 || loQueDurasteALV == 92)
        {
            score1UI.GetComponent<Animator>().SetBool("1", false);
            score1UI.GetComponent<Animator>().SetBool("2", true);
        }
        else if (loQueDurasteALV == 3 || loQueDurasteALV == 13 || loQueDurasteALV == 23 || loQueDurasteALV == 33
            || loQueDurasteALV == 43 || loQueDurasteALV == 53 || loQueDurasteALV == 63 || loQueDurasteALV == 73
            || loQueDurasteALV == 83 || loQueDurasteALV == 93)
        {
            score1UI.GetComponent<Animator>().SetBool("2", false);
            score1UI.GetComponent<Animator>().SetBool("3", true);
        }
        else if (loQueDurasteALV == 4 || loQueDurasteALV == 14 || loQueDurasteALV == 24 || loQueDurasteALV == 34
            || loQueDurasteALV == 44 || loQueDurasteALV == 54 || loQueDurasteALV == 64 || loQueDurasteALV == 74
            || loQueDurasteALV == 84 || loQueDurasteALV == 94)
        {
            score1UI.GetComponent<Animator>().SetBool("3", false);
            score1UI.GetComponent<Animator>().SetBool("4", true);
        }
        else if (loQueDurasteALV == 5 || loQueDurasteALV == 15 || loQueDurasteALV == 25 || loQueDurasteALV == 35
            || loQueDurasteALV == 45 || loQueDurasteALV == 55 || loQueDurasteALV == 65 || loQueDurasteALV == 75
            || loQueDurasteALV == 85 || loQueDurasteALV == 95)
        {
            score1UI.GetComponent<Animator>().SetBool("4", false);
            score1UI.GetComponent<Animator>().SetBool("5", true);
        }
        else if (loQueDurasteALV == 6 || loQueDurasteALV == 16 || loQueDurasteALV == 26 || loQueDurasteALV == 36
            || loQueDurasteALV == 46 || loQueDurasteALV == 56 || loQueDurasteALV == 66 || loQueDurasteALV == 76
            || loQueDurasteALV == 86 || loQueDurasteALV == 96)
        {
            score1UI.GetComponent<Animator>().SetBool("5", false);
            score1UI.GetComponent<Animator>().SetBool("6", true);
        }
        else if (loQueDurasteALV == 7 || loQueDurasteALV == 17 || loQueDurasteALV == 27 || loQueDurasteALV == 37
            || loQueDurasteALV == 47 || loQueDurasteALV == 57 || loQueDurasteALV == 67 || loQueDurasteALV == 77
            || loQueDurasteALV == 87 || loQueDurasteALV == 97)
        {
            score1UI.GetComponent<Animator>().SetBool("6", false);
            score1UI.GetComponent<Animator>().SetBool("7", true);
        }
        else if (loQueDurasteALV == 8 || loQueDurasteALV == 18 || loQueDurasteALV == 28 || loQueDurasteALV == 38
            || loQueDurasteALV == 48 || loQueDurasteALV == 58 || loQueDurasteALV == 68 || loQueDurasteALV == 78
            || loQueDurasteALV == 88 || loQueDurasteALV == 98)
        {
            score1UI.GetComponent<Animator>().SetBool("7", false);
            score1UI.GetComponent<Animator>().SetBool("8", true);
        }
        else if (loQueDurasteALV == 9 || loQueDurasteALV == 19 || loQueDurasteALV == 29 || loQueDurasteALV == 39
            || loQueDurasteALV == 49 || loQueDurasteALV == 59 || loQueDurasteALV == 69 || loQueDurasteALV == 79
            || loQueDurasteALV == 89 || loQueDurasteALV == 99 || loQueDurasteALV >= 100)
        {
            score1UI.GetComponent<Animator>().SetBool("8", false);
            score1UI.GetComponent<Animator>().SetBool("9", true);
        }
        if (loQueDurasteALV < 10)
        {
            score2UI.GetComponent<Animator>().SetBool("9", false);
            score2UI.GetComponent<Animator>().SetBool("0", true);
        }
        else if (loQueDurasteALV >= 10 && loQueDurasteALV < 20)
        {
            score2UI.GetComponent<Animator>().SetBool("0", false);
            score2UI.GetComponent<Animator>().SetBool("1", true);
        }
        else if (loQueDurasteALV >= 20 && loQueDurasteALV < 30)
        {
            score2UI.GetComponent<Animator>().SetBool("1", false);
            score2UI.GetComponent<Animator>().SetBool("2", true);
        }
        else if (loQueDurasteALV >= 30 && loQueDurasteALV < 40)
        {
            score2UI.GetComponent<Animator>().SetBool("2", false);
            score2UI.GetComponent<Animator>().SetBool("3", true);
        }
        else if (loQueDurasteALV >= 40 && loQueDurasteALV < 50)
        {
            score2UI.GetComponent<Animator>().SetBool("3", false);
            score2UI.GetComponent<Animator>().SetBool("4", true);
        }
        else if (loQueDurasteALV >= 50 && loQueDurasteALV < 60)
        {
            score2UI.GetComponent<Animator>().SetBool("4", false);
            score2UI.GetComponent<Animator>().SetBool("5", true);
        }
        else if (loQueDurasteALV >= 60 && loQueDurasteALV < 70)
        {
            score2UI.GetComponent<Animator>().SetBool("5", false);
            score2UI.GetComponent<Animator>().SetBool("6", true);
        }
        else if (loQueDurasteALV >= 70 && loQueDurasteALV < 80)
        {
            score2UI.GetComponent<Animator>().SetBool("6", false);
            score2UI.GetComponent<Animator>().SetBool("7", true);
        }
        else if (loQueDurasteALV >= 80 && loQueDurasteALV < 90)
        {
            score2UI.GetComponent<Animator>().SetBool("7", false);
            score2UI.GetComponent<Animator>().SetBool("8", true);
        }
        else if (loQueDurasteALV >= 90)
        {
            score2UI.GetComponent<Animator>().SetBool("8", false);
            score2UI.GetComponent<Animator>().SetBool("9", true);
        }
    }
}
