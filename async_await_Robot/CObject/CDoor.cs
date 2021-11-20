using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace async_await_Robot
{
    class CDoor:CBase
    {
        /* public string strName 
           protected Pen _Pen
           protected SolidBrush _Brush */

        public Rectangle _rtDoorSide;   //문 테두리
        public Rectangle _rtDoor;       //뼈대(채워진거)


        public CDoor(string sName)   
        {
            strName = sName;
            _Pen = new Pen(Color.WhiteSmoke, 3);            //펜 굵기
            _Brush = new SolidBrush(Color.WhiteSmoke);      //내부를 채울 색상

            _rtDoorSide = new Rectangle(10, 45, 20, 60); 
            _rtDoor = new Rectangle(10, 45, 20, 60);

        }


        //protected인 Pen,SolidBrush를 외부 접근용
        public Pen fPenInfo()
        {
            return _Pen;
        }

        public SolidBrush fBruchInfo()
        {
            return _Brush;
        }


        #region Door Y Move
        //fSuareMove(iMove) 움직임 외부접근용 
        public void fMove(int iMove)
        {
            fSquareMove(iMove);
        }

        private void fSquareMove(int iMove)
        {
            Point oPoint = _rtDoor.Location;   
            oPoint.Y = oPoint.Y + iMove;
            _rtDoor.Location = oPoint;
        }

        #endregion
    }
}
