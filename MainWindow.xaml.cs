using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace DrawingChecker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            

            for (int i = 0; i < 16; i++)
            {
                mainDataGrid.Columns.Add(new DataGridTextColumn
                {
                    Header = (i + 1).ToString(),
                    Width = new DataGridLength(1, DataGridLengthUnitType.Star)
                }) ;
                mainDataGrid.Items.Add("") ;


            }
        }

        private void mainDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dataGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (button.Background == Brushes.Black) button.Background = Brushes.White;
            
            else button.Background = Brushes.Black;

            RowsList.Rows[mainDataGrid.SelectedIndex, mainDataGrid.CurrentColumn.DisplayIndex] = true;

            string result = "";
            for (int i = 0; i < 16; i++)
            {
                if (button.Background == Brushes.Black)
                {
                    result += RowsList.Rows[mainDataGrid.SelectedIndex, i] ? 1 : 0;
                }
                else
                {
                    RowsList.Rows[mainDataGrid.SelectedIndex, mainDataGrid.CurrentColumn.DisplayIndex] = false;
                    result += RowsList.Rows[mainDataGrid.SelectedIndex, i] ? 1 : 0;
                }
            }
            MarkedList.isMarked[mainDataGrid.SelectedIndex] = Convert.ToInt32(result, 2).ToString("X4");
        }
        private void tableShow_Click(object sender, RoutedEventArgs e)
        {
            TableWindow tableWindow = new TableWindow();
            tableWindow.Show();
        }


        private void CheckAnswers_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 16; i++)
            {
                if ((mainDockPanel.Children[i] as TextBox).Text.Length != 0)
                {
                    if ((mainDockPanel.Children[i] as TextBox).Text != MarkedList.isMarked[i])
                    {
                        MessageBox.Show("Неверно! Проверьте ещё раз");
                        return;
                    }
                }
                else
                {
                    ErrorWindow errorWindow = new ErrorWindow();
                    errorWindow.errorTextBlock.Text = "Вы заполнили не все поля!";
                    errorWindow.Show();
                    break;
                }
            }
            MessageBox.Show("Верно!");
        } 


        private void DockPanel_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 16; i++)
            {
                TextBox textBox = new TextBox();
                textBox.SetValue(DockPanel.DockProperty, Dock.Top);
                textBox.Name = "t" + i.ToString();
                textBox.Height = 32;
                textBox.FontSize = 18;
                mainDockPanel.Children.Add(textBox);

                ManagerAnswers.Answers.Add("");
            }
        }
    }
}
