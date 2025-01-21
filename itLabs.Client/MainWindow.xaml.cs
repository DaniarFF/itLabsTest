using System.Windows;

namespace itLabs
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      MainFrame.Navigate(new Page1());
    }
  }
}