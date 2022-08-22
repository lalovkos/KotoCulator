using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KotoCulator
{
    public class KotoCulator
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var mainWindow = new MainWindow();
            Task.Run(() => mainWindow.Show());
        }
    }
}
