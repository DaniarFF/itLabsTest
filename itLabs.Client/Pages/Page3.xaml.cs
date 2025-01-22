using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace itLabs.Client;

/// <summary>
///   Логика взаимодействия для Page3.xaml
/// </summary>
public partial class Page3 : Page
{
  private readonly string _expectedCode = "000";
  private string _userInput;

  public Page3()
  {
    InitializeComponent();
  }

  /// <summary>
  ///   Перевод фокуса ввода на следующее поле.
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void TextBoxMoveFocus(object sender, TextChangedEventArgs e)
  {
    if (sender is TextBox currentTextBox && currentTextBox.Text.Length == 1)
    {
      var request = new TraversalRequest(FocusNavigationDirection.Next);
      currentTextBox.MoveFocus(request);
    }
  }

  /// <summary>
  ///   Проверка введённого кода и переход на следующую страницу в случае совпажения.
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private async void CheckCodeButton_Click(object sender, RoutedEventArgs e)
  {
    _userInput = string.Empty;

    var isValid = true;

    foreach (var element in InputField.Children)
    {
      if (element is TextBox textBox)
      {
        var input = textBox.Text.Trim();

        if (input.Length == 1 && char.IsDigit(input[0]))
          _userInput += input;
        else
          isValid = false;
      } 
    }
    
    if (isValid && _userInput == _expectedCode)
    {
      SetTextBoxBorderColor(Brushes.Green);

      ShowMessage("Код принят", Brushes.Green);

      await Task.Delay(500);

      NavigationService.Navigate(new Page4());
    }
    else
    {
      SetTextBoxBorderColor(Brushes.Red);

      ShowMessage("Код введен неверно", Brushes.Red);
    }
  }

  /// <summary>
  ///   Установка цвета границ текстовых полей.
  /// </summary>
  /// <param name="brush"></param>
  private void SetTextBoxBorderColor(Brush brush)
  {
    foreach (UIElement element in InputField.Children)
      if (element is TextBox textBox)
        textBox.BorderBrush = brush;
  }

  /// <summary>
  ///   Отображение сообщения.
  /// </summary>
  /// <param name="message">Сообщение</param>
  /// <param name="brush">Цвет сообщения</param>
  private async void ShowMessage(string message, Brush brush)
  {
    var statusLabel = FindName("Message") as Label;
    if (statusLabel != null)
    {
      statusLabel.Content = message;
      statusLabel.Foreground = brush;
      statusLabel.Visibility = Visibility.Visible;
    }

    await Task.Delay(3000);

    statusLabel.Visibility = Visibility.Hidden;
  }

  /// <summary>
  ///   Повторная отправка сообщения с кодом
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void SendMessageWithCodeButton_Click(object sender, RoutedEventArgs e)
  {
    ShowMessage("Сообщение с кодом отправлено повторно", Brushes.Green);
  }
}