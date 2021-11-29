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
                    Start_Move();
                    break;

                //비동기 동작 진행
                case "btnAsynchronous":
                    Start_Move_Async();
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
                case "btnRobotRotate":
                    RobotRotate();
                    break;

                default:
                    break;
            }

            Log(enLogLevel.Info_L1, $"Button Name : {btn.Name}");
            lboxLog.Items.Insert(0, "\r\n");

        }

        //동작 Delay m/s. 지정해준 시간에 따라 변경되는 속도
        private void tboxDelay_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(tboxDelay.Text, out int iRet))
            {
                _iSpeed = iRet;
            }

            //_iSpeed = int.Parse(tboxDelay.Text);
        }



        #region function Draw

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
        private void fDoor1Draw(int iMove)
        {
            this.Invoke(new Action(delegate ()
            {
                pDoor1.Refresh();

                _cDoor1.fMove(iMove);  //Door1 Y 움직일 위치정보

                //pDoor1에 그림그리기 시작
                Graphics g = pDoor1.CreateGraphics();

                g.DrawRectangle(_cDoor1.fPenInfo(), _cDoor1._rtDoorSide);  //테두리 사각형 그리기
                g.FillRectangle(_cDoor1.fBruchInfo(), _cDoor1._rtDoor);    //채워진 사각형
            }));
        }

        //pDoor2에 그리기 함수
        private void fDoor2Draw(int iMove)
        {
            this.Invoke(new Action(delegate ()
            {
                pDoor2.Refresh();

                _cDoor2.fMove(iMove);  //Door2 Y 움직일 위치정보

                //pDoor2에 그림그리기 시작
                Graphics g = pDoor2.CreateGraphics();

                g.DrawRectangle(_cDoor2.fPenInfo(), _cDoor2._rtDoorSide);  
                g.FillRectangle(_cDoor2.fBruchInfo(), _cDoor2._rtDoor);    
            }));
        }


        // pRobot에 그리기 함수
        // 로봇 몸통(회전O), 팔, 물건. 3가지 정보가 pRobot에 그려져야함
        // 몸통 -> 팔 -> 물건의 순서로 그려져야함
        private void fRobotDraw(int iRotate, int iRobot_Arm_Move, bool isObject)
        {
            this.Invoke(new Action(delegate ()
            {
                pRobot.Refresh();

                //pRobot에 그림그리기 시작
                Graphics g = pRobot.CreateGraphics();

                g.FillEllipse(_cRobot.fBrushInfo(), _cRobot._rtCircle_Robot);  //몸통 그리기

                _cRobot.fMove(iRobot_Arm_Move);   //팔 X 움직일 위치정보
                                                  
                Point center = new Point(85, 75);
                g.Transform = GetMatrix(center, iRotate);  // 팔 회전(위치,회전각)

                g.DrawRectangle(_cRobot.fPenInfo(), _cRobot._rtSquare_Arm);    //팔 그리기


                // Object가 있을 경우(true) 물건 그리기. 없으면 패스
                if (isObject)
                {
                    g.FillRectangle(_cRobot.fBrushInfo(), _cRobot._rtSquare_Object);  //물건 그리기
                }
            }));
        }

        // Robot 회전 시 사용 하는 함수 (실제 Robot이 회전하는게 아니고 Robot Arm을 Robot 중심 기준으로 회전 시킴)
        private Matrix GetMatrix(Point centerPoint, float rotateAngle)
        {
            Matrix matrix = new Matrix();

            matrix.RotateAt(rotateAngle, centerPoint);

            return matrix;
        }

        #endregion


        #region Task

        //동기 동작 진행 함수
        private void Start_Move()
        {
            //동기 동작 버튼 누르고 아무것도 못 하니까 Task사용. 전체에 Task
            Task.Run(() =>
            {
                Log(enLogLevel.Info_L2, "Move Sequence Start");

                Door1Open();
                RobotArmExtend();
                Thread.Sleep(500);     
                _bObjectExist = true;
                RobotArmRetract();
                Door1Close();
                RobotRotate();

                Door2Open();
                RobotArmExtend();
                Thread.Sleep(500);
                _bObjectExist = false;
                RobotArmRetract();
                Door2Close();
                RobotRotate();

                Log(enLogLevel.Info_L2, "Move Sequence Complete");
            });
        }

        //비동기 동작 진행 함수. 띄어쓰기로 구별해 놓은게 동시동작의 묶음임
        // Task : 비동기함수
        // await : 비동기 함수가 끝날 때 까지 잡아놓는 것. Task - await는 세트
        // async : await를 위해서 async라는 한정자를 써야함

        private async void Start_Move_Async()
        {
            Log(enLogLevel.Info_L2, "Move Sequence Start");

            Task vTask;

            vTask = Task.Run(() => RobotArmExtend());   //팔을 뻗으면서
            await Task.Run(() => Door1Open());      //문을 열기. await->동작이 끝날 때 까지 다음 동작을 수행하지 않겠다

            Thread.Sleep(500);     
            _bObjectExist = true;  // 물건을 가지고 나오게
            await Task.Run(() => RobotArmRetract());  //팔을 접으면서 물건을 가지고 나옴

            vTask = Task.Run(() => Door1Close());
            await Task.Run(() => RobotRotate());

            vTask = Task.Run(() => RobotArmExtend());
            await Task.Run(() => Door2Open());

            Thread.Sleep(500);
            _bObjectExist = false;  
            await Task.Run(() => RobotArmRetract());

            vTask = Task.Run(() => Door2Close());
            await Task.Run(() => RobotRotate());

            Log(enLogLevel.Info_L2, "Move Sequence Complete");
        }

        #endregion

        
        #region function 단위동작
        // 모든 함수들은 Draw함수를 호출. 제대로 값을 줘서 작동하기 위함이다

        private void Door1Open()
        {
            int Door = _cDoor1._rtDoor.Bottom;  // 정해진 범위 이상 올라가지 않게 하기 위해

            for (int i = 0; i < 10; i++)
            {
                if (Door != 55)  //Door이 105. -5씩 10번 감소되니까 50. 105 - 50 = 55(완전히 열렸을때)
                {
                    Thread.Sleep(_iSpeed);
                    fDoor1Draw(-5);   //Thread로 잠시 멈췄다가 y좌표 -5 그리기
                }
            }

            if (Door == 55)
            {
                Log(enLogLevel.Warning, "The Door Is Already Open");
                return;
            }

            Log(enLogLevel.Info_L1, "Door1 Open Start");
            Log(enLogLevel.Info_L1, "Door1 Open Complete");

        }


        private void Door1Close()
        {
            int Door = _cDoor1._rtDoor.Y;    //정해진 범위 이상 내려가지 않게 하기 위해

            for (int i = 0; i < 10; i++)
            {
                if (Door != 40)
                {
                    Thread.Sleep(_iSpeed);
                    fDoor1Draw(5);   //Thread로 잠시 멈췄다가 y좌표 -5 그리기
                }
            }

            if (Door == 40)
            {
                Log(enLogLevel.Warning, "The Door Is Already Closed");
                return;
            }

            Log(enLogLevel.Info_L1, "Door1 Open Start");
            Log(enLogLevel.Info_L1, "Door1 Open Complete");

        }

        private void Door2Open()
        {
            int Door = _cDoor2._rtDoor.Bottom;  

            for (int i = 0; i < 10; i++)
            {
                if (Door != 55)
                {
                    Thread.Sleep(_iSpeed);
                    fDoor2Draw(-5);   //Thread로 잠시 멈췄다가 y좌표 -5 그리기
                }
            }

            if (Door == 55)
            {
                Log(enLogLevel.Warning, "The Door Is Already Open");
                return;
            }

            Log(enLogLevel.Info_L1, "Door2 Open Start");
            Log(enLogLevel.Info_L1, "Door2 Open Complete");
        }


        private void Door2Close()
        {
            int Door = _cDoor2._rtDoor.Y;    

            for (int i = 0; i < 10; i++)
            {
                if (Door != 40)
                {
                    Thread.Sleep(_iSpeed);
                    fDoor2Draw(5);  
                }
            }

            if (Door == 40)
            {
                Log(enLogLevel.Warning, "The Door Is Already Closed");
                return;
            }

            Log(enLogLevel.Info_L1, "Door2 Close Start");
            Log(enLogLevel.Info_L1, "Door2 Close Complete");
        }

        
        private void RobotArmExtend()
        {
            for (int i = 0; i < 8; i++)
            {
                if(_cRobot._rtSquare_Arm.X != -5)
                {
                    Thread.Sleep(_iSpeed);
                    fRobotDraw(_iRobot_Rotate, -5, _bObjectExist);
                }
            }

            Log(enLogLevel.Info_L1, "Robot Arm Extend Start");
            Log(enLogLevel.Info_L1, "Robot Arm Extend Complete");
        }

        private void RobotArmRetract()
        {
            for (int i = 0; i < 8; i++)
            {
                if(_cRobot._rtSquare_Arm.X != 25)
                {
                    Thread.Sleep(_iSpeed);

                    fRobotDraw(_iRobot_Rotate, 5, _bObjectExist);
                }
            }

            Log(enLogLevel.Info_L1, "Robot Arm Retract Start");
            Log(enLogLevel.Info_L1, "Robot Arm Retract Complete");
        }

        //180도 회전. 12번 15도로 
        private void RobotRotate()
        {
            for(int i=0; i<12; i++)       //12 * 15 = 180
            {
                Thread.Sleep(_iSpeed);
                _iRobot_Rotate = _iRobot_Rotate + 15;  

                fRobotDraw(_iRobot_Rotate, 0, _bObjectExist);
            }

            if (_iRobot_Rotate > 360) _iRobot_Rotate -= 360;

            Log(enLogLevel.Info_L1, "Robot Rotate Start");
            Log(enLogLevel.Info_L1, "Robot Rotate Complete");
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
