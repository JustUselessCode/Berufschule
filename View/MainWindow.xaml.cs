using CDMangager.Model;
using System;
using System.Windows;


namespace CDMangager;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ManagerFunctionality.OpenXMLDatabase(@"S:\Tim-Zander\1 - SWD\CD_Datenbank\CD.xml");
    }

    private void OpenDBButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void SaveDBButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void PreviousCDButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void NextCDButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void FindCDButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void AddCDButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void SaveExitButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void CDListBox_Initialized(object sender, EventArgs e)
    {
        CDListBox.ItemsSource = ManagerFunctionality.CurrentCDList;
        CDListBox.SelectedIndex = 0;
    }
}
