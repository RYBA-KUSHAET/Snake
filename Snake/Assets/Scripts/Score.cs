using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Константа с ключом лучшего счёта — так игра сможет быстрее находить его в памяти устройства
    private const string BestScoreKey = "BestScore";

    // Переменная надписи о счёте
    private TextMeshProUGUI _scoreText;

    // Переменная для хранения счёта
    private int _score;

    // Переменная для хранения лучшего счёта
    private int _bestScore;

    // Start is called before the first frame update
    void Start()
    {
        // Вызываем метод FillComponents()
        FillComponents();

        // Передаём в метод SetScore() значение 0 (сбрасываем счёт)
        SetScore(0);

        // Вызываем метод LoadBestScore()
        LoadBestScore();
    }

    public void AddScore(int value)
    {
        // Передаём в метод SetScore() сумму _score и value
        SetScore(_score + value);
    }

    public void Restart()
    {
        // Передаём в метод SetScore() значение 0 (сбрасываем счёт)
        SetScore(0);
    }

    public int GetScore()
    {
        // Возвращаем текущий счёт
        return _score;
    }

    public int GetBestScore()
    {
        // Возвращаем лучший счёт
        return _bestScore;
    }

    public void SetBestScore(int value)
    {
        // Присваиваем лучшему счёту значение value
        _bestScore = value;

        // Передаём в метод SaveBestScore() значение value
        SaveBestScore(value);
    }

    private void FillComponents()
    {
        // Находим компонент TextMeshProUGUI у дочерних объектов того объекта, на котором висит скрипт (у нас это будет Score), и присваиваем значение компонента переменной _scoreText
        _scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void SetScore(int value)
    {
        // Присваиваем текущему счёту значение value
        _score = value;

        // Передаём в метод SetScoreText() значение value
        SetScoreText(value);
    }

    private void SetScoreText(int value)
    {
        // Преобразуем value в строку и присваиваем его свойству text компонента _scoreText
        _scoreText.text = value.ToString();
    }

    private void LoadBestScore()
    {
        // Присваиваем _bestScore значение, сохранённое в PlayerPrefs с ключом BestScoreKey
        _bestScore = PlayerPrefs.GetInt(BestScoreKey);
    }

    private void SaveBestScore(int value)
    {
        // Сохраняем value в PlayerPrefs с ключом BestScoreKey
        PlayerPrefs.SetInt(BestScoreKey, value);
    }

}
