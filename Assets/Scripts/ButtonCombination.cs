using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Text;
using System;

public class ButtonCombination : MonoBehaviour
{
    public EmptyEvent OnStartButtonCombination = new EmptyEvent();

    public StringEvent OnStartButtonCombinationDrop = new StringEvent();

    public EmptyEvent OnCombinationComplete = new EmptyEvent();

    public IntEvent OnNewIndex = new IntEvent();

    public StringEvent OnNewCombination = new StringEvent();

    public EmptyEvent OnGoodButton = new EmptyEvent();

    public EmptyEvent OnBadButton = new EmptyEvent();

    List<KeyCode> Combinations = new List<KeyCode>();

    List<KeyCode> PossibleKeys = new List<KeyCode>()
    {
        KeyCode.Q,
        KeyCode.W,
        KeyCode.E,
        KeyCode.R,
        KeyCode.T,
        KeyCode.Y,
        KeyCode.U,
        KeyCode.I,
        KeyCode.O,
        KeyCode.P,
        KeyCode.A,
        KeyCode.S,
        KeyCode.D,
        KeyCode.F,
        KeyCode.G,
        KeyCode.H,
        KeyCode.J,
        KeyCode.K,
        KeyCode.L,
        KeyCode.Z,
        KeyCode.X,
        KeyCode.C,
        KeyCode.V,
        KeyCode.B,
        KeyCode.N,
        KeyCode.M,
    };

    [SerializeField]
    int numButtons = 0;

    [SerializeField]
    bool isRandom = false;

    [SerializeField]
    List<TextAsset> words = new List<TextAsset>();

    List<string> possibleWords = new List<string>();

    List<KeyCode> combination = new List<KeyCode>();

    int index = 0;

    bool isDoingTest = false;

    public Player CurrentPlayer = null;

    // Start is called before the first frame update
    void Start()
    {
        OnStartButtonCombination.AddListener(() =>
        {
            if (!isDoingTest)
            {
                if (isRandom)
                {
                    CreateRandomButtonCombination();
                }
                else
                {
                    CreateStringCombination();
                }
            }
        });
        OnStartButtonCombinationDrop.AddListener(SetStringCombination);
        OnNewCombination.AddListener((unused) =>
        {
            //Debug.LogWarning("NEW COMBINATION: " + unused);
            if (CurrentPlayer != null)
            {
                CurrentPlayer.GivenWord = unused;
            }
            isDoingTest = true;
            index = 0;
        });
        OnCombinationComplete.AddListener(() =>
        {
            isDoingTest = false;
        });

        ParseWords();
    }

    void ParseWords()
    {
        foreach (var asset in words)
        {
            foreach (var word in asset.text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                possibleWords.Add(word.ToUpper());
            }
        }
    }

    public void StartButtonCombination()
    {
        OnStartButtonCombination.Invoke();
    }

    private void Update()
    {
        if (isDoingTest)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(combination[index]))
                {
                    index++;
                    if (index == combination.Count)
                    {
                        //Debug.Log("Lock Complete!");
                        OnCombinationComplete.Invoke();
                    }
                    else
                    {
                        //Debug.Log("Lock: " + index);
                        OnNewIndex.Invoke(index);
                        OnGoodButton.Invoke();
                    }
                }
                else
                {
                    //Debug.Log("Lock BAD");
                    //Bad combination
                    index = 0;
                    OnNewIndex.Invoke(index);
                    OnBadButton.Invoke();
                }
            }
        }
    }

    void CreateRandomButtonCombination()
    {
        combination.Clear();
        for (int i = 0; i < numButtons; i++)
        {
            combination.Add(PossibleKeys[UnityEngine.Random.Range(0, PossibleKeys.Count)]);
        }

        StringBuilder sb = new StringBuilder();

        foreach (var e in combination)
        {
            sb.Append(Enum.GetName(typeof(KeyCode), e).ToUpper());
        }

        Debug.LogWarning(sb.ToString());

        OnNewCombination.Invoke(sb.ToString());
    }

    void CreateStringCombination()
    {
        combination.Clear();
        var combo = possibleWords[UnityEngine.Random.Range(0, possibleWords.Count)];

        Debug.LogWarning(combo);

        combination.AddRange(StringToCodes(combo));

        OnNewCombination.Invoke(combo);
    }

    void SetStringCombination(string code)
    {
        combination.Clear();
        combination.AddRange(StringToCodes(code));
        OnNewCombination.Invoke(code);
    }

    public static List<KeyCode> StringToCodes(string text)
    {
        List<KeyCode> toReturn = new List<KeyCode>(text.Length);

        foreach (var character in text.ToUpper())
        {
            try
            {
                toReturn.Add((KeyCode)Enum.Parse(typeof(KeyCode), "" + character));
            }
            catch
            {
                continue;
            }
        }

        return toReturn;
    }
}
