using Neutrition.Pages.editpages;
using Neutrition.Pages.regpages;
using Neutrition.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Neutrition
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int curPageIndex = 0;
        private List<Page> pages = new List<Page>() { new regpage1(), new regpage2(), new regpage3(), new regpage4(), new regpage5(), new regpage6(), new regpage7() };
        private Person person = new Person();

        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        public Register()
        {
            InitializeComponent();
            Person.BirthDate = DateTime.Now;
            Person.GoalDate = DateTime.Now;
            DataContext = this;
            RegContentFrame.Navigate(pages[curPageIndex]);
            InitPages();
        }

        public Register(EditPerson editPersonPage)
        {
            InitializeComponent();
            editPersonPage.Save_BTN.Click += Save_BTN_Click;
            editPersonPage.Cancel_BTN.Click += Cancel_BTN_Click;
            RegContentFrame.Navigate(editPersonPage);

        }

        private void InitPages()
        {
            ((regpage1)pages[0]).NextButton.Click += Next_Bnt;
            ((regpage2)pages[1]).NextButton.Click += Next_Bnt;
            ((regpage2)pages[1]).PrevButton.Click += Prev_Bnt;
            ((regpage3)pages[2]).NextButton.Click += Next_Bnt;
            ((regpage3)pages[2]).PrevButton.Click += Prev_Bnt;
            ((regpage4)pages[3]).NextButton.Click += Next_Bnt;
            ((regpage4)pages[3]).PrevButton.Click += Prev_Bnt;
            ((regpage5)pages[4]).PrevButton.Click += Prev_Bnt;
            ((regpage5)pages[4]).NextButton.Click += Next_Bnt;
            ((regpage6)pages[5]).PrevButton.Click += Prev_Bnt;
            ((regpage6)pages[5]).NextButton.Click += Next_Bnt;
            ((regpage7)pages[6]).PrevButton.Click += Prev_Bnt;
            ((regpage7)pages[6]).NextButton.Click += Fin_Btn;
            pages[0].DataContext = this;
            pages[1].DataContext = this;
            pages[2].DataContext = this;
            pages[3].DataContext = this;
            pages[4].DataContext = this;
            pages[5].DataContext = this;
            pages[6].DataContext = this;
        }

        private void Next_Bnt(object sender, RoutedEventArgs e)
        {
            curPageIndex++;
            if (curPageIndex >= pages.Count)
            {
                curPageIndex = pages.Count - 1;
            }
            RegContentFrame.Navigate(pages[curPageIndex]);
        }

        private void Prev_Bnt(object sender, RoutedEventArgs e)
        {
            curPageIndex--;
            if (curPageIndex < 0)
            {
                curPageIndex = 0;
            }
            RegContentFrame.Navigate(pages[curPageIndex]);
        }

        private void Fin_Btn(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }


        private void Save_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true; // Editnél mentés
            this.Close();
        }

        private void Cancel_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false; // Editnél cancel
            this.Close();
        }

    }
}
