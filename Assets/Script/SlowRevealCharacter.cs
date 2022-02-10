using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlowRevealCharacter : MonoBehaviour
{
    private TextMeshProUGUI _textMiki;
    private bool done;
    private IEnumerator Start()
    {
        _textMiki = gameObject.GetComponent<TextMeshProUGUI>();
        _textMiki.ForceMeshUpdate();
        int totalVisibleCharacters = _textMiki.textInfo.characterCount;
        int counter = 0;
        done = false;

        while (!done)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            _textMiki.maxVisibleCharacters = visibleCount;
            if (visibleCount >= totalVisibleCharacters)
            {
                done = true;
                yield return new WaitForSeconds(0.01f);
            }

            counter += 1;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void RevealCharacter()
    {
        StartCoroutine(Start());
    }
}
