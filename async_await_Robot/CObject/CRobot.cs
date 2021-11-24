using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace async_await_Robot
{
    class CRobot:CBase
    {
        /* public string strName 
           protected Pen _Pen
           protected SolidBrush _Brush */

        public Rectangle _rtCircle_Robot;    //로봇몸통
        public Rectangle _rtSquare_Arm;      //로봇팔
        public Rectangle _rtSquare_Object;   //로봇이 잡고 움직 일 물건


        public CRobot(string sName)
        {
            strName = sName;
            _Pen = new Pen(Color.WhiteSmoke, 3);
            _Brush = new SolidBrush(Color.WhiteSmoke);

            _rtCircle_Robot = new Rectangle(33, 25, 100, 100);
            _rtSquare_Arm = new Rectangle(25, 65, 80, 20);
            _rtSquare_Object = new Rectangle(10, 55, 20, 40);

        }

        public Pen fPenInfo()
        {
            return _Pen;
        }

        public SolidBrush fBrushInfo()
        {
            return _Brush;
        }

        #region Robot의 몸통은 회전,팔을 회전 이동 필요

        //fSuareMove(iMove) 움직임 외부접근용 
        public void fMove(int iMove)
        {
            fSquareMove(iMove);
        }

        private void fSquareMove(int iMove)
        {
            //Robot Arm을 움직임(x좌표)
            Point oPoint = _rtSquare_Arm.Location;
            oPoint.X = oPoint.X + iMove;
            _rtSquare_Arm.Location = oPoint;


            //Robot Object도 Arm과 함께 움직인다. 물건을 꺼내올때만 보임. 보이고/안보이고
            //Arm과 함께 움직이기 때문에 따로 Point 생성 안해주고 같은거 사용
            oPoint = _rtSquare_Object.Location;      
            oPoint.X = oPoint.X + iMove;
            _rtSquare_Object.Location = oPoint;


        }


        #endregion
    }
}
