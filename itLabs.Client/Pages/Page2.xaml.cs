using itLabs.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace itLabs;

/// <summary>
///   Логика взаимодействия для Page2.xaml
/// </summary>
public partial class Page2 : Page
{
  private readonly Dictionary<string, string> _defaultTextBoxContent = new()
  {
    { "firstTextBox", "Фамилия, Имя, Отчество" },
    { "secondTextBox", "Ваш телефон" },
    { "thirdTextBox", "E-mail" }
  };

  private Dictionary<string, string> _userInput = new Dictionary<string, string>();
  private HttpClient _httpClient;

  private readonly string token = "htfIEhF8E3zOb8SmXBqRCDxxzcLKNHCI2ex2LICyj20";

  private readonly string serverUri = "https://localhost:7165/api/customer";

  public Page2()
  {
    InitializeComponent();
    _httpClient = new HttpClient
    {
      BaseAddress = new Uri(serverUri)
    };
  }

  /// <summary>
  ///  Обработка введенных данных при нажатии на кнопку
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private async void SubmitButton_Click(object sender, RoutedEventArgs e)
  {
    var isValid = true;

    foreach (var entry in _defaultTextBoxContent)
    {
      var textBox = FindName(entry.Key) as TextBox;
      if (textBox != null)
      {
        if (!ValidateTextBox(entry.Key, textBox))
        {
          isValid = false;
          continue;
        }

        textBox.BorderBrush = Brushes.Green;
        _userInput[entry.Key] = textBox.Text;
      }
    }

    if (isValid)
    {
      var request = CreateCustomerRequest();
      await NavigateAndSaveData(sender, e, request);
    }
  }

  /// <summary>
  ///  Проверка корректности введённых данных
  /// </summary>
  /// <param name="key"></param>
  /// <param name="textBox"></param>
  /// <returns></returns>
  private bool ValidateTextBox(string key, TextBox textBox)
  {
    var inputValidation = new InputValidation();

    if (string.IsNullOrWhiteSpace(textBox.Text) || _defaultTextBoxContent[key] == textBox.Text)
    {
      textBox.BorderBrush = Brushes.Red;
      ShowMessage("Пожалуйста, заполните все поля корректно.", Brushes.Red);
      return false;
    }

    switch (key)
    {
      case "firstTextBox":
        if (!inputValidation.ValidateFullName(textBox.Text))
        {
          textBox.BorderBrush = Brushes.Red;
          ShowMessage("Некорректно введено имя. Введите в формате: Фамилия Имя Отчество.", Brushes.Red);
          return false;
        }

        break;

      case "secondTextBox":
        if (!inputValidation.ValidatePhoneNumber(textBox.Text))
        {
          textBox.BorderBrush = Brushes.Red;
          ShowMessage("Некорректно введен телефон. Формат: +79999999999.", Brushes.Red);
          return false;
        }

        break;

      case "thirdTextBox":
        if (!inputValidation.ValidateEmail(textBox.Text))
        {
          textBox.BorderBrush = Brushes.Red;
          ShowMessage("Некорректно введен email. Убедитесь, что адрес правильный.", Brushes.Red);
          return false;
        }

        break;
    }

    return true;
  }

  private NewCustomerRequest CreateCustomerRequest()
  {
    _userInput.TryGetValue("firstTextBox", out string? name);
    _userInput.TryGetValue("secondTextBox", out string? phone);
    _userInput.TryGetValue("thirdTextBox", out string? mail);

    var userData = new NewCustomerRequest()
    {
      Email = mail,
      Name = name,
      Phone = phone
    };

    return userData;
  }

  /// <summary>
  ///  Переход на третью страницу
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private async Task NavigateAndSaveData(object sender, RoutedEventArgs e, NewCustomerRequest newCustomerRequest)
  {
    var jsonData = JsonSerializer.Serialize(newCustomerRequest);
    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

    var request = new HttpRequestMessage(HttpMethod.Post, serverUri);
    request.Headers.Add("x-api-key", token);
    request.Content = content;

    var response = await _httpClient.SendAsync(request);

    if (response.IsSuccessStatusCode)
    {
      NavigationService.Navigate(new Page3());
    }
    else
    {
      var message = "Ошибка при отправке данных";
      ShowMessage(message, Brushes.Red);
    }

  }

  /// <summary>
  ///  Отображение сообщения
  /// </summary>
  /// <param name="message"></param>
  /// <param name="brush"></param>
  private void ShowMessage(string message, Brush brush)
  {
    var statusLabel = FindName("FailMessage") as Label;
    if (statusLabel != null)
    {
      statusLabel.Content = message;
      statusLabel.Foreground = brush;
      statusLabel.Visibility = Visibility.Visible;
    }
  }


  /// <summary>
  ///  Обрабатывает событие получения фокуса пользователя текстовым полем.
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void TextBoxGotFocus(object sender, RoutedEventArgs e)
  {
    if (sender is TextBox textBox && _defaultTextBoxContent.TryGetValue(textBox.Name, out var defaultContent))
      if (textBox.Text == defaultContent)
      {
        textBox.Text = string.Empty;
        textBox.Foreground = Brushes.White;
        textBox.FontStyle = FontStyles.Normal;
      }
  }

  /// <summary>
  ///  Обрабатывает событие потери фокуса пользователя над текстовым полем.
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void TextBoxLostFocus(object sender, RoutedEventArgs e)
  {
    if (sender is TextBox textBox && _defaultTextBoxContent.TryGetValue(textBox.Name, out var defaultContent))
      if (string.IsNullOrWhiteSpace(textBox.Text))
      {
        textBox.Text = defaultContent;
        textBox.Foreground = Brushes.Gray;
        textBox.FontStyle = FontStyles.Italic;
      }
  }
}