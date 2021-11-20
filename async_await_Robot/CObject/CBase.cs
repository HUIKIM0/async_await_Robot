using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace async_await_Robot       //.CObject (폴더명)삭제함
{
    class CBase
    {
        public string strName;
        protected Pen _Pen;
        protected SolidBrush _Brush;


        public CBase()
        {
            _Pen = new Pen(Color.Aqua);
        }
    }
}
