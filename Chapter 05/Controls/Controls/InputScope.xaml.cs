using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Reflection;

namespace Controls
{
    public partial class InputScope : PhoneApplicationPage
    {
        public InputScope()
        {
            InitializeComponent();
            InitializeInputScopeList();
        }

        private void InitializeInputScopeList()
        {
            foreach (string strInputScope in GetNames(typeof(InputScopeNameValue)))
            {
                listInputScope.Items.Add(strInputScope);
            } 
        }

        public string[] GetNames(Type enumeration)
{
    List<string> names = new List<string>();
    FieldInfo[] infoCollection = enumeration.GetFields(BindingFlags.Public | BindingFlags.Static);
    foreach (FieldInfo fi in infoCollection)
    {
        names.Add(fi.Name);
    }
    return names.ToArray();
}

        private void listInputScope_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1)
                return;

            InputScopeNameValue val;

            if (Enum.IsDefined(typeof(InputScopeNameValue), listInputScope.SelectedItem))
            {
                val = (InputScopeNameValue)Enum.Parse(typeof(InputScopeNameValue), listInputScope.SelectedItem.ToString(), true);

                try
                {
                    System.Windows.Input.InputScope inputScope = new System.Windows.Input.InputScope();
                    InputScopeName inputScopeName = new InputScopeName();
                    inputScopeName.NameValue = val;
                    inputScope.Names.Add(inputScopeName);

                    txtInput.InputScope = inputScope;
                    txtInputScopeName.Text = listInputScope.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    // do nothing
                }
            }


        }

    }
}