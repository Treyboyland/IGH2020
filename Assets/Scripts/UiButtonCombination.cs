using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButtonCombination : MonoBehaviour
{
    [SerializeField]
    ButtonCombinationLetter letterPrefab = null;

    [SerializeField]
    ButtonCombination combo = null;

    List<ButtonCombinationLetter> currentLetters = new List<ButtonCombinationLetter>();

    // Start is called before the first frame update
    void Start()
    {
        combo.OnNewCombination.AddListener(GenerateLetters);
        combo.OnNewIndex.AddListener((index) =>
        {
            foreach (var letter in currentLetters)
            {
                letter.SolvedCombination(index);
            }
        });
        combo.OnCombinationComplete.AddListener(() =>
        {
            foreach (var letter in currentLetters)
            {
                letter.gameObject.SetActive(false);
            }
            currentLetters.Clear();
        });
    }

    void GenerateLetters(string combo)
    {
        currentLetters.Clear();
        GamePool.Pool.DisableAll(letterPrefab);

        for (int i = 0; i < combo.Length; i++)
        {
            var letter = (ButtonCombinationLetter)GamePool.Pool.GetObject(letterPrefab);
            letter.Index = i;
            letter.Character = "" + combo[i];
            letter.transform.SetParent(transform, false);
            letter.gameObject.SetActive(true);
            letter.SolvedCombination(0);
            currentLetters.Add(letter);
        }
    }
}
