using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharpWin1
{   
    //열거형으로 데이터 타입 정의
    public enum Operators { Add, Sub, Multi, Div }

    public partial class Calulator : Form
    {
        //계산기 결과를 0으로 초기화
        public int Result = 0;
        // 숫자가 처음 들어온건지 확인하려고 bool 변수 만듬 
        public bool isNewNum = true;
        // 열거형 데이터 하나 만들어서 초기화 해둠 리액트 state 같은 개념으로 사용하려고
        public Operators Opt = Operators.Add;

        public Calulator()
        {
            InitializeComponent();
        }

        public int Add(int number1, int number2)
        {
            int sum = number1 + number2;
            return sum;
        }

        public float Add(float number1, float number2)
        {
            float sum = number1 + number2;
            return sum;
        }

        public int Sub(int number1, int number2)
        {
            int sub = number1 + number2;
            return sub;
        }

        // 버튼 1 클릭 이벤트시 
        private void NumButton1_Click(object sender, EventArgs e)
        {    
            // 버튼 변수를 만들어서 이벤트 발생 시 object로 sender 받은걸 변환 
            Button numButton = (Button)sender;
            // 받은 오브젝트중에 텍스트 부분을 NumScreen에 넣음
            SetNum(numButton.Text);
        }

        // 버튼으로 입력 받은 것을 NumScreen에 저장하는 함수
        public void SetNum(string num) 
        {    
            // 들어온 숫자가 처음인지 확인
            처음이면 
            if (isNewNum)
            {
                NumScreen.Text = num;
                isNewNum = false;
            }
            else if (NumScreen.Text == "0")
            {
                NumScreen.Text = num;
            }
            //처음이 아니면 더해줌 
            else
            {
                NumScreen.Text = NumScreen.Text + num;
            }

        }
        // 더하기 이벤트 함수
        private void NumPlus_Click(object sender, EventArgs e)
        {    
            if (isNewNum == false)
            {   
                // 들어온 스트링을 int로 변환하고 
                int num = int.Parse(NumScreen.Text);
                // Add 모드인지 확인하고
                if (Opt == Operators.Add)
                    Result = Result + num;
                // 아니면 - 모드
                else if (Opt == Operators.Sub)
                    Result = Result - num;
                // int 연산 후 다시 스트링으로 변환해주고 텍스트에 저장
                NumScreen.Text = Result.ToString();

                // 다시 계산 할때 첫 입력인지 확인해야되니까 true로 바꿔줌
                isNewNum = true;
            }

            // 초기값 Add 이고 버튼에 있는 텍스트를 읽어와서 + 버튼누른지 - 버튼 누른지 확인
            Button optButton = (Button)sender;
            if (optButton.Text == "+")
                // +모드로 변경
                Opt = Operators.Add;

            else if (optButton.Text == "-")
                // -모드로 변경
                Opt = Operators.Sub;

        }

        // 0으로 스크린 초기화 함수
        private void NumClear_Click(object sender, EventArgs e)
        {
            Result = 0;
            isNewNum = true;
            Opt = Operators.Add;

            NumScreen.Text = "0";
        }
    }       

}
