using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HistoryManager : MonoBehaviour
{
    [SerializeField] List<JornalPage> ListJournalPage;
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] private Button NextButton;
    [SerializeField] private Button PreviousButton;
    [SerializeField] private Button OpenJornalButton;
    [SerializeField] private Button CloseJornalButton;
    [SerializeField] private GameObject Jornal;

    private int i;


    private void OnEnable()
    {
        i = 0;
        Text.text = ListJournalPage[i].PageText;

        PreviousButton.gameObject.SetActive(false);
        NextButton.onClick.AddListener(NextHistory);
        PreviousButton.onClick.AddListener(PreviousHistory);
        OpenJornalButton.onClick.AddListener(OpenJornal);
        CloseJornalButton.onClick.AddListener(CloseJornal);
    }

    private void CloseJornal()
    {
        Jornal.SetActive(false);
    }

    private void OpenJornal()
    {
        Jornal.SetActive(true);
    }

    public void NextHistory()
    {
        if (i < ListJournalPage.Count - 1)
        {
            i++;
        }

        if (i == ListJournalPage.Count - 1)
        {
            NextButton.gameObject.SetActive(false);
        }

        if (i > 0)
        {
            PreviousButton.gameObject.SetActive(true);
        }

        Text.text = ListJournalPage[i].PageText;
    }

    public void PreviousHistory()
    {
        if (0 < i)
        {
            i--;
        }

        if (i == 0)
        {
            PreviousButton.gameObject.SetActive(false);
        }

        if (i > 0)
        {
            NextButton.gameObject.SetActive(true);
        }

        Text.text = ListJournalPage[i].PageText;
    }

    private void OnDisable()
    {
        NextButton.onClick.RemoveListener(NextHistory);
        PreviousButton.onClick.RemoveListener(PreviousHistory);
        OpenJornalButton.onClick.RemoveListener(OpenJornal);
        CloseJornalButton.onClick.RemoveListener(CloseJornal);
    }
}
