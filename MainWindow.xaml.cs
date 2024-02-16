using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_DynamicControls_2024_02_07;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    
    
    public MainWindow()
    {
        InitializeComponent();
        KeyBinding escapeBinding = new KeyBinding(ApplicationCommands.Close, Key.Escape, ModifierKeys.None);
        
        InputBindings.Add(escapeBinding);
        
    }
    
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
       TxtQty.Focus();
    }

    private void BtnCreate_OnClick(object sender, RoutedEventArgs e)
    {
        Wp.Children.Clear();
        if(int.TryParse(TxtQty.Text, out var qty))
        {
            for (var i = 0; i < qty; i++)
            {
                var btn = new Button
                {
                    Content = $"Button {i + 1}",
                    Margin = new Thickness(5),
                    MinWidth = 100,
                    Height = (20 + i)*1.5,
                    FontSize = 10 + i,
                    Tag = i + 1, 
                    Background = Brushes.LightBlue,
                };
                btn.Click += Btn_Click;
                
                Wp.Children.Add(btn);
            }
        }
    }
    
    private void Btn_Click(object sender, RoutedEventArgs e) 
    {
        Button btn = (Button) sender;
        MessageBox.Show($"Button {btn.Tag} wurde geklickt!", "Hinweis");
        Wp.Children.Remove(btn);
    }
    
    
    private void Clear()
    {
        Wp.Children.Clear();
    }
    

}