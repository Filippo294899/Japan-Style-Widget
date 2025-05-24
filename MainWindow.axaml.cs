using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.ComponentModel;
using Avalonia.Threading;
using Avalonia.Media;

namespace MyWidgetApp;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private string _currentTime;
    public string CurrentTime
    {
        get => _currentTime;
        set
        {
            _currentTime = value;
            OnPropertyChanged(nameof(CurrentTime));
        }
    }

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
         var fontFamily = new FontFamily("avares://MyWidgetApp/Assets/Osake.ttf#Osake");
        this.FindControl<TextBlock>("MyTextBlock").FontFamily = fontFamily;
        this.FindControl<TextBlock>("MyTextBlock").FontSize = 40;
   
        this.Position = new PixelPoint(
            (int)(Screens.Primary.WorkingArea.Width / 2 - this.Width / 2),
            (int)(Screens.Primary.WorkingArea.Height / 2 - this.Height / 2)
        );
        

        UpdateTime();

        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        timer.Tick += (s, e) => UpdateTime();
        timer.Start();
    }

    private void UpdateTime()
    {
        CurrentTime = DateTime.Now.ToString("HH : mm : ss");
        
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}