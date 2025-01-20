using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace itLabs
{
  /// <summary>
  ///  Логика взаимодействия для первой страницы приложения
  /// </summary>
  public partial class Page1 : Page
  {
    /// <summary>
    ///  Конструктор
    /// </summary>
    public Page1()
    {
      InitializeComponent();
    }
    
    /// <summary>
    ///  Переход на вторую страницу
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NavigateToPage2(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new Page2());
    }
  }
}
