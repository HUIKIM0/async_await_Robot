using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async_await_Robot
{
    public partial class Form1 : Form
    {
        #region 전역

        CRobot _cRobot;           //class CRobot 선언
        CDoor _cDoor1, _cDoor2;    //class CDoor 선언

        int _iRobot_Rotate = 0;  // Robot Rotate 
        int _iSpeed = 100;  // Thread Sleep Time
        bool _bObjectExist = false;   // Robot이 Object를 가지고 있는지 여부


        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        //Form Load와 동시에 class 생성
        private void Form1_Load(object sender, EventArgs e)
        {
            _cRobot = new CRobot("Robot");
            _cDoor1 = new CDoor("DoorLeft");
            _cDoor2 = new CDoor("DoorRight");
        }


        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                //초기 화면 표시
                case "btnGraphics":
                    fGenericsDraw();
                    break;

                //동기 동작 진행
                case "btnSynchronous":
                    break;

                //비동기 동작 진행
                case "btnAsynchronous":
                    break;

                case "btnD1Open":
                    Door1Open();
                    break;
                case "btnD1Close":
                    Door1Close();
                    break;

                case "btnD2Open":
                    Door2Open();
                    break;
                case "btnD2Close":
                    Door2Close();
                    break;

                case "btnArmExtend":
                    RobotArmExtend();
                    break;
                case "btnArmRetract":
                    RobotArmRetract();
                    break;

                default:
                    break;
            }

            Log(enLogLevel.Info_L1, $"Button Name : {btn.Name}");
            lboxLog.Items.Insert(0, "\r\n");

        }

        //동작 Delay m/s. 지정해준 시간에 따라 문이 올라가는 속도
        private void tboxDelay_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(tboxDelay.Text, out int iRet))
            {
                _iSpeed = iRet;
            }
        }



        #region function 

        /// <summary>
        /// 초기 화면 표시. 초기값들 / 그림그리는 함수를 호출
        /// </summary>
        private void fGenericsDraw()
        {
            _cRobot = null;
            _cDoor1 = null;
            _cDoor2 = null;
            _iRobot_Rotate = 0;
            _iSpeed = 100;
            _bObjectExist = false;

            _cRobot = new CRobot("Robot");
            _cDoor1 = new CDoor("DoorLeft");
            _cDoor2 = new CDoor("DoorRight");


            fDoor1Draw(0);
            fDoor2Draw(0);
            fRobotDraw(_iRobot_Rotate, 0, false);

        }


        //pDoor1에 그리기 함수
        //
        private void fDoor1Draw(int iMove)
        {
            pDoor1.Refresh();

            _cDoor1.fMove(iMove);  //Door1위치정보

            //pDoor1에 그림그리기!
            Graphics g = pDoor1.CreateGraphics();

            g.DrawRectangle(_cDoor1.fPenInfo(), _cDoor1._rtDoorSide);  //테두리 그리기
            g.FillRectangle(_cDoor1.fBruchInfo(), _cDoor1._rtDoor);    //채우기
        }

        //pDoor2에 그리기 함수
        private void fDoor2Draw(int iMove)
        {
            pDoor2.Refresh();

            _cDoor2.fMove(iMove);  //Door2위치정보

            //pDoor2에 그림그리기!
            Graphics g = pDoor2.CreateGraphics();

            g.DrawRectangle(_cDoor2.fPenInfo(), _cDoor2._rtDoorSide);  //테두리 그리기
            g.FillRectangle(_cDoor2.fBruchInfo(), _cDoor2._rtDoor);    //채우기
        }


        // pRobot에 그리기 함수
        // 로봇 몸통(회전), 팔, 물건. 3가지 정보가 pRobot에 그려져야함
        private void fRobotDraw(int iRotate, int iRobot_Arm_Move, bool isObject)
        {
            pRobot.Refresh();

            _cRobot.fMove(iRobot_Arm_Move);   //팔 위치정보

            //pRobot에 그림그리기!
            Graphics g = pRobot.CreateGraphics();


            g.DrawRectangle(_cRobot.fPenInfo(), _cRobot._rtSquare_Arm);    //팔 그리기
            g.FillEllipse(_cRobot.fBrushInfo(), _cRobot._rtCircle_Robot);  //몸통 그리기


            // 팔 회전
            Point center = new Point(100 , 100);
            g.Transform = GetMatrix(center, iRotate);


            // Object가 있을 경우 표시 하고 없을 경우 표시 하지 않음
            if (isObject)
            {
                g.FillRectangle(_cRobot.fBrushInfo(), _cRobot._rtSquare_Object);  //물건 그리기
            }

        }

        // Robot 회전 시 사용 하는 함수 (실제 Robot이 회전하는게 아니고 Robot Arm을 Robot 중심 기준으로 회전 시킴)
        private Matrix GetMatrix(Point centerPoint, float rotateAngle)
        {
            Matrix matrix = new Matrix();

            matrix.RotateAt(rotateAngle, centerPoint);

            return matrix;
        }


        #endregion



        #region function

        private void Door1Open()
        {

            int Door = _cDoor1._rtDoor.Bottom;  // 정해진 범위 이상 올라가지 않게 하기 위해

            for (int i = 0; i < 10; i++)
            {
                if (Door != 60)
                {
                    Thread.Sleep(_iSpeed);
                    fDoor1Draw(-5);   //Thread로 잠시 멈췄다가 y좌표 -5 그리기
                }
            }

            if (Door == 60)
            {
                Log(enLogLevel.Info_L2, "The Door Is Already Open");
                return;
            }

            Log(enLogLevel.Info_L1, "Door1 Open Complete");
            Log(enLogLevel.Info_L1, "Door1 Open Start");
        }


        private void Door1Close()
        {
            int Door = _cDoor1._rtDoor.Y;    //정해진 범위 이상 내려가지 않게 하기 위해

            for (int i = 0; i < 10; i++)
            {
                if (Door != 45)
                {
                    Thread.Sleep(_iSpeed);
                    fDoor1Draw(5);   //Thread로 잠시 멈췄다가 y좌표 -5 그리기
                }
            }

            if (Door == 45)
            {
                Log(enLogLevel.Info_L2, "The Door Is Already Closed");
                return;
            }

            Log(enLogLevel.Info_L1, "Door1 Open Complete");
            Log(enLogLevel.Info_L1, "Door1 Open Start");
        }

        private void Door2Open()
        {
            int Door = _cDoor2._rtDoor.Bottom;  // 정해진 범위 이상 올라가지 않게 하기 위해

            for (int i = 0; i < 10; i++)
            {
                if (Door != 60)
                {
                    Thread.Sleep(_iSpeed);
                    fDoor2Draw(-5);   //Thread로 잠시 멈췄다가 y좌표 -5 그리기
                }
            }

            if (Door == 60)
            {
                Log(enLogLevel.Info_L2, "The Door Is Already Open");
                return;
            }

            Log(enLogLevel.Info_L1, "Door1 Open Complete");
            Log(enLogLevel.Info_L1, "Door1 Open Start");

        }


        private void Door2Close()
        {
            int Door = _cDoor2._rtDoor.Y;    //정해진 범위 이상 내려가지 않게 하기 위해

            for (int i = 0; i < 10; i++)
            {
                if (Door != 45)
                {
                    Thread.Sleep(_iSpeed);
                    fDoor2Draw(5);   //Thread로 잠시 멈췄다가 y좌표 -5 그리기
                }
            }

            if (Door == 45)
            {
                Log(enLogLevel.Info_L2, "The Door Is Already Closed");
                return;
            }

            Log(enLogLevel.Info_L1, "Door1 Open Complete");
            Log(enLogLevel.Info_L1, "Door1 Open Start");
        }

        
        private void RobotArmExtend()
        {

            for (int i = 0; i < 8; i++)
            {
                if(_cRobot._rtSquare_Arm.X != 0)
                {
                    Thread.Sleep(_iSpeed);
                    fRobotDraw(_iRobot_Rotate, -5, _bObjectExist);
                }
               
            }

            Log(enLogLevel.Info_L1, "Robot Arm Extend Complete");
            Log(enLogLevel.Info_L1, "Robot Arm Extend Start");
        }

        private void RobotArmRetract()
        {

            for (int i = 0; i < 8; i++)
            {
                if(_cRobot._rtSquare_Arm.X != 30)
                {
                    Thread.Sleep(_iSpeed);
                    fRobotDraw(_iRobot_Rotate, 5, _bObjectExist);
                }
            }

            Log(enLogLevel.Info_L1, "Robot Arm Retract Complete");
            Log(enLogLevel.Info_L1, "Robot Arm Retract Start");
        }


        #endregion



        #region Log Viewer 

        // Log Level을 지정 할 Enum
        enum enLogLevel
        {
            Info_L1,
            Info_L2,
            Info_L3,
            Warning,
            Error,
        }


        //사용자가 시간정보 X 버전
        private void Log(enLogLevel eLevel, string LogDesc)
        {
            this.Invoke(new Action(delegate ()    //Thread 에러 방지 this.Invoke(new Action(delegate ()
            {
                DateTime dTime = DateTime.Now;
                string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
                lboxLog.Items.Insert(0, LogInfo);
            }));
        }



        //사용자가 시간정보O 버전
        private void Log(DateTime dTime, enLogLevel eLevel, string LogDesc)
        {
            this.Invoke(new Action(delegate ()
            {
                string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
                lboxLog.Items.Insert(0, LogInfo);
            }));
        }

        #endregion


    }
}
