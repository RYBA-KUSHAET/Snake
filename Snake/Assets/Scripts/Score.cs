using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // ��������� � ������ ������� ����� � ��� ���� ������ ������� �������� ��� � ������ ����������
    private const string BestScoreKey = "BestScore";

    // ���������� ������� � �����
    private TextMeshProUGUI _scoreText;

    // ���������� ��� �������� �����
    private int _score;

    // ���������� ��� �������� ������� �����
    private int _bestScore;

    // Start is called before the first frame update
    void Start()
    {
        // �������� ����� FillComponents()
        FillComponents();

        // ������� � ����� SetScore() �������� 0 (���������� ����)
        SetScore(0);

        // �������� ����� LoadBestScore()
        LoadBestScore();
    }

    public void AddScore(int value)
    {
        // ������� � ����� SetScore() ����� _score � value
        SetScore(_score + value);
    }

    public void Restart()
    {
        // ������� � ����� SetScore() �������� 0 (���������� ����)
        SetScore(0);
    }

    public int GetScore()
    {
        // ���������� ������� ����
        return _score;
    }

    public int GetBestScore()
    {
        // ���������� ������ ����
        return _bestScore;
    }

    public void SetBestScore(int value)
    {
        // ����������� ������� ����� �������� value
        _bestScore = value;

        // ������� � ����� SaveBestScore() �������� value
        SaveBestScore(value);
    }

    private void FillComponents()
    {
        // ������� ��������� TextMeshProUGUI � �������� �������� ���� �������, �� ������� ����� ������ (� ��� ��� ����� Score), � ����������� �������� ���������� ���������� _scoreText
        _scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void SetScore(int value)
    {
        // ����������� �������� ����� �������� value
        _score = value;

        // ������� � ����� SetScoreText() �������� value
        SetScoreText(value);
    }

    private void SetScoreText(int value)
    {
        // ����������� value � ������ � ����������� ��� �������� text ���������� _scoreText
        _scoreText.text = value.ToString();
    }

    private void LoadBestScore()
    {
        // ����������� _bestScore ��������, ���������� � PlayerPrefs � ������ BestScoreKey
        _bestScore = PlayerPrefs.GetInt(BestScoreKey);
    }

    private void SaveBestScore(int value)
    {
        // ��������� value � PlayerPrefs � ������ BestScoreKey
        PlayerPrefs.SetInt(BestScoreKey, value);
    }

}
