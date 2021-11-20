using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                    break;
                case "btnD1Close":
                    break;

                case "btnD2Open":
                    break;
                case "btnD2Close":
                    break;

                default:
                    break;
            }

            Log(enLogLevel.Info_L1, $"BtnTest : {btn.Name}");

        }

        #region function

        /// <summary>
        /// 초기 화면 표시. 그림이 틀어졌을 경우를 대비하여 만든 함수
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

        }


        //pDoor1에 그리기 함수
        private void fDoor1Draw(int iMove)
        {
            pDoor1.Refresh();

            _cDoor1.fMove(iMove);  

            //pDoor1에 그림그리기!
            Graphics g = pDoor1.CreateGraphics();

            g.DrawRectangle(_cDoor1.fPenInfo(), _cDoor1._rtDoorSide);  //테두리 그리기
            g.FillRectangle(_cDoor1.fBruchInfo(), _cDoor1._rtDoor);    //채우기
        }

        //pDoor2에 그리기 함수
        private void fDoor2Draw(int iMove)
        {
            pDoor2.Refresh();

            _cDoor2.fMove(iMove);  //위치정보 함수

            //pDoor2에 그림그리기!
            Graphics g = pDoor2.CreateGraphics();

            g.DrawRectangle(_cDoor2.fPenInfo(), _cDoor2._rtDoorSide);  //테두리 그리기
            g.FillRectangle(_cDoor2.fBruchInfo(), _cDoor2._rtDoor);    //채우기
        }


        //pRobot에 그리기 함수
        private void fRobotDraw(int iRotate, int iRobot_Arm_Move, bool isObject)
        {

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
