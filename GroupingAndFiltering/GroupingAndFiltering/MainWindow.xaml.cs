using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Data;

namespace GroupingAndFiltering
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string sConn = @"Server=(local)\AURORA; Database=AdventureWorks2012;Trusted_Connection=true";
            SqlConnection conn = new SqlConnection(sConn);
            string sSQL = "SELECT * FROM [Production].[Product] ORDER BY ProductLine, Name";
            SqlCommand comm;
            SqlDataReader DR;
            DataTable DT = new DataTable();

            conn.Open();
            comm = new SqlCommand(sSQL, conn);
            DR = comm.ExecuteReader();
            DT.Load(DR);
            LayoutGrid.DataContext = DT;
            DR.Close();
            conn.Close();
        }

        private void GroupCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(LayoutGrid.DataContext);
            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(new PropertyGroupDescription("ProductLine"));
        }

        private void GroupCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(LayoutGrid.DataContext);
            view.GroupDescriptions.Clear();
        }

        private void FilterCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ((DataTable)LayoutGrid.DataContext).DefaultView.RowFilter = "Color='Black'";
        }

        private void FilterCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ((DataTable)LayoutGrid.DataContext).DefaultView.RowFilter = "";
        }
    }
}