using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FifteenButton
{
    public class ChessMan : Button
    {
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int Index { get; set; }
    }
}
