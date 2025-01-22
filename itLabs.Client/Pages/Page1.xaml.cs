using System.Windows;
using System.Windows.Controls;

namespace itLabs;

/// <summary>
///   Логика взаимодействия для первой страницы приложения
/// </summary>
public partial class Page1 : Page
{
  /// <summary>
  ///   Конструктор
  /// </summary>
  public Page1()
  {
    InitializeComponent();
  }

  /// <summary>
  ///   Переход на вторую страницу
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void NavigateToPage2(object sender, RoutedEventArgs e)
  {
    NavigationService.Navigate(new Page2());
  }
}