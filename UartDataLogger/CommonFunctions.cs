using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UartDataLogger.Common
{
    static class CommonFunctions
    {
        public static void showError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.TargetSite.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
