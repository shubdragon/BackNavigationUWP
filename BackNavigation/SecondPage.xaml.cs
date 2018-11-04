using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Profile;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BackNavigation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondPage : Page
    {
        public SecondPage()
        {
            this.InitializeComponent();
            MainFrame.Navigated += MainFrame_Navigated;
            this.Loaded += SecondPage_Loaded;
            
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            foreach (var item in rootFrame.BackStack.ToList())
            rootFrame.BackStack.Remove(item);
        }

        private void SecondPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Frame rootFrame = Window.Current.Content as Frame;
            //foreach (var item in rootFrame.BackStack.ToList())
            //rootFrame.BackStack.Remove(item);
            Frame frame = Window.Current.Content as Frame;
            frame.BackStack.RemoveAt(frame.BackStackDepth - 1);
            MainFrame.Navigate(typeof(Frame1));
        }        
       
        private void Frame2Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CurrentSourcePageType != typeof(Frame2))
            {
                MainFrame.Navigate(typeof(Frame2));
            }
        }

        private void Frame3Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CurrentSourcePageType != typeof(Frame3))
            {
                MainFrame.Navigate(typeof(Frame3));
            }
        }

        private void FrameBackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;

            if (MainFrame.Content is Frame1)
            {
                frame.Navigate(typeof(MainPage));
            }
            else
            {                
                if (MainFrame.CanGoBack)
                    MainFrame.GoBack();
            }
        }

    }
}
