using Studio.Shiba.Win32Helpers;
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

namespace IconExtractorTestWindow;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.AllowDrop = true;
        this.Drop += Window_Drop;
    }

    private void Window_Drop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            if (e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                var filepath = files[0];
                var iconset = IconExtractor.ExtractIconFromPath(filepath);
                if (iconset.SmallIcon != null)
                {
                    this.small.Source = iconset.SmallIcon;
                }
                if (iconset.LargeIcon != null)
                {
                    this.large.Source = iconset.LargeIcon;
                }
                if (iconset.ExtraLargeIcon != null)
                {
                    this.xlarge.Source = iconset.ExtraLargeIcon;
                }
                if (iconset.LargeIcon != null)
                {
                    this.xxlarge.Source = iconset.JumboIcon;
                }
            }
        }
    }
}
