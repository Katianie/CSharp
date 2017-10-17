using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Archive_Searcher
{
    public class ArchiveMain
    {
        [STAThread]
        public static void Main(String[] args)
        {
            frmArchiveSearcher theArchiveSearcher = new frmArchiveSearcher();

            Application.Run(theArchiveSearcher);
        }
    }
}
