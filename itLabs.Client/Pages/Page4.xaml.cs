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

namespace itLabs.Client
{
  /// <summary>
  /// Логика взаимодействия для Page4.xaml
  /// </summary>
  public partial class Page4 : Page
  {
    public Page4()
    {
      InitializeComponent();
      NavigateToFirstPageAfterDelay();
    }

    /// <summary>
    ///  Переход на первую страницу через 20 секунд
    /// </summary>
    private async void NavigateToFirstPageAfterDelay()
    {
      await Task.Delay(20000);

      this.NavigationService?.Navigate(new Page1());
    }
  }
}
